﻿namespace DataNS
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateApi()
        {
            return new DataAPI();
        }
    }
    
}