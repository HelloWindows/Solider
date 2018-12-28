/*******************************************************************
 * FileName: ITimer.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Model {
        namespace Interface {
            public interface ITimer {
                bool isCD { get; }
                float schedule { get; }
                float time { get;}
                float CD { get; }
            } // end interface ITimer 
        } // end namespace Interface
    } // end namespace Model
} // end namespace Solider