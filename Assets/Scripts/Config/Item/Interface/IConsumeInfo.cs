/*******************************************************************
 * FileName: IConsumeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IConsumeInfo : IItemInfo {
                int HP { get; }
                int MP { get; }
                float HPR { get; }
                float MPR { get; }
                float XHR { get; }
                float XMR { get; }
                int CD { get; }
                IBuffInfo buff { get; }
            } // end interface IConsumeInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider