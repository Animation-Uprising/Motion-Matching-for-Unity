using UnityEngine;

namespace MxM
{
    [System.Serializable]
    public class CalibrationData
    {
        public string CalibrationName;

        public float PoseTrajectoryRatio = 0.6f;
        public float PoseVelocityWeight = 3f;
        public float PoseAspectMultiplier = 1f;
        public float PoseResultantVelocityMultiplier = 0.2f;
        public float TrajPosMultiplier = 5f;
        public float TrajFAngleMultiplier = 0.04f;
        public float[] JointPositionWeights;
        public float[] JointVelocityWeights;

        public CalibrationData()
        {

        }

        public CalibrationData(CalibrationData a_copy)
        {
            CalibrationName = a_copy.CalibrationName;
            PoseTrajectoryRatio = a_copy.PoseTrajectoryRatio;
            PoseVelocityWeight = a_copy.PoseVelocityWeight;
            PoseAspectMultiplier = a_copy.PoseAspectMultiplier;
            PoseResultantVelocityMultiplier = a_copy.PoseResultantVelocityMultiplier;
            TrajPosMultiplier = a_copy.TrajPosMultiplier;
            TrajFAngleMultiplier = a_copy.TrajFAngleMultiplier;

            JointPositionWeights = new float[a_copy.JointPositionWeights.Length];
            JointVelocityWeights = new float[a_copy.JointVelocityWeights.Length];

            for(int i=0; i < a_copy.JointPositionWeights.Length; ++i)
            {
                JointPositionWeights[i] = a_copy.JointPositionWeights[i];
                JointVelocityWeights[i] = a_copy.JointVelocityWeights[i];
            }
        }

        public void Initialize(string a_name, MxMAnimData a_animData)
        {
            CalibrationName = a_name;

            if (a_animData != null)
            {
                JointPositionWeights = new float[a_animData.MatchBones.Length];
                JointVelocityWeights = new float[a_animData.MatchBones.Length];

                for(int i=0; i < JointPositionWeights.Length; ++i)
                    JointPositionWeights[i] = 3f;

                for (int i = 0; i < JointVelocityWeights.Length; ++i)
                    JointVelocityWeights[i] = 1f;
            }
            else
            {
                Debug.LogError("Error: Trying to construct calibration data with null MxMAnimData");
            }
        }

        public void Validate(MxMAnimData a_parentAnimData)
        {
            if (a_parentAnimData == null)
            {
                Debug.LogError("Error: Trying to construct calibration data with null MxMAnimData");
                return;
            }
            
                if (a_parentAnimData.MatchBones.Length != JointPositionWeights.Length)
                {
                    float[] newJointPosWeights = new float[a_parentAnimData.MatchBones.Length];
                    float[] newJointVelWeights = new float[a_parentAnimData.MatchBones.Length];

                    for (int i = 0; i < newJointPosWeights.Length; ++i)
                    {
                        if (i < JointPositionWeights.Length)
                        {
                            newJointPosWeights[i] = JointPositionWeights[i];
                            newJointVelWeights[i] = JointVelocityWeights[i];
                        }
                        else
                        {
                            newJointPosWeights[i] = 3;
                            newJointVelWeights[i] = 1;
                        }
                    }

                    JointPositionWeights = newJointPosWeights;
                    JointVelocityWeights = newJointVelWeights;
                }
        }

        public bool IsValid(MxMAnimData a_parentAnimData)
        {
            if (a_parentAnimData == null)
                return false;

            if (JointPositionWeights.Length != a_parentAnimData.MatchBones.Length)
                return false;

            if(JointVelocityWeights.Length != a_parentAnimData.MatchBones.Length)
                return false;

            return true;
        }
    }//End of class: CalibrationData
}//End of namespace: MxM
