using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MxM
{

    [CreateAssetMenu(fileName = "TrajGenModule", menuName = "MxM/Utility/TrajGenModule", order = 1)]
    public class TrajectoryGeneratorModule : ScriptableObject
    {
        [Header("Motion Settings")]
        [Tooltip("The maximum speed of the trajectory with full stick")]
        public float MaxSpeed = 4.3f;

        [Tooltip("How responsive the trajectory movement is. Higher numbers make the trajectory move faster")]
        public float PosBias = 9f;

        [Tooltip("How responsive the trajectory direction is. Higher numbers make the trajectory direction rotate faster")]
        public float DirBias = 9f;

        [Tooltip("The mode that the trajectory is in. Changes the behaviour of the trajectory")]
        public ETrajectoryMoveMode TrajectoryMode = ETrajectoryMoveMode.Normal;

        [Tooltip("Should the trajectory be flattened to have no vertical movement")]
        public bool FlattenTrajectory;

        [Header("CustomInput")]
        [Tooltip("If checked, the user must set the InputVector property on the trajectory for it to function. This allows" +
            "for custom trajectory manipulation.")]
        public bool CustomInput;

        [Tooltip("If checked, the trajectory direction will be reset to the character facing direction when there is no input." +
            "This helps stop strange stopping behavior.")]
        public bool ResetDirectionOnNoInput;

        [Header("Other")]
        [Tooltip("The camera that this trajectory is being generated relative to.")]
        public Transform CamTransform;

        [Tooltip("The input profile to use to shape the trajectory to valid ranges of input.")]
        public MxMInputProfile InputProfile;
    }
}