﻿// Copyright © 2017-2024 Vault Break Studios Pty Ltd

using UnityEngine;

namespace MxM
{
    //============================================================================================
    /**
    *  @brief A pose either saved to file or interpolated between two poses which is used
    *  for pose matching an motion matching
    *         
    *********************************************************************************************/
    [System.Serializable]
    public struct JointData
    {
        public Vector3 Position;
        public Vector3 Velocity;

        //============================================================================================
        /**
        *  @brief Constructor for joint data
        *  
        *  @param [Vector3] _pos
        *  @param
        *         
        *********************************************************************************************/
        public JointData(Vector3 _pos, Vector3 _vel)
        {
            Position = _pos;
            Velocity = _vel;
        }

    }//End of struct: JointData
}//End of namespace: MxM
