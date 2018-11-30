/*******************************************************************
 * FileName: IGameSetting.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Model {
        namespace Interface {
            public interface IGameSetting {
                float musicValue { get; }
                float soundValue { get; }
                string currentQuality { get; }
                void SetMusicValue(float value);
                void SetSoundValue(float value);
                void SetQuality(string name);
            } // end class IGameSetting 
        } // end namespace Interface
    } // end namespace Model
} // end namespace Solider