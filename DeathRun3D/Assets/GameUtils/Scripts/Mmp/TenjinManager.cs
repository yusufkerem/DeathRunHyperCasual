using UnityEngine;

namespace YsoCorp {

    namespace GameUtils {

        [DefaultExecutionOrder(-10)]
        public class TenjinManager : MmpBaseManager {

            private static string API_KEY = "BP2IBD5EPSJLBT2JYHWDGTVGXQVF6YGK";

            private BaseTenjin _tenjin;

            public override void Init() {
                if (this._tenjin == null) {
                    this._tenjin = Tenjin.getInstance(API_KEY);
#if UNITY_IOS
                    this._tenjin.RegisterAppForAdNetworkAttribution();
                    this._tenjin.Connect();
#elif UNITY_ANDROID
                    this._tenjin.Connect();
#endif
                }
            }

            int GetInters() {
                int inters = this.ycManager.dataManager.GetInterstitialsNb();
                if (inters >= 50) { return 7; } // 111
                if (inters >= 25) { return 6; } // 110
                if (inters >= 20) { return 5; } // 101
                if (inters >= 15) { return 4; } // 100
                if (inters >= 10) { return 3; } // 011
                if (inters >= 5) { return 2; } // 010
                if (inters >= 1) { return 1; } // 001
                return 0; // 000
            }

            int GetRewards() {
                int rewardes = this.ycManager.dataManager.GetRewardedsNb();
                if (rewardes >= 20) { return 56; } // 111000
                if (rewardes >= 15) { return 48; } // 110000
                if (rewardes >= 10) { return 40; } // 101000
                if (rewardes >= 5) { return 32; } // 100000
                if (rewardes >= 3) { return 24; } // 011000
                if (rewardes >= 2) { return 16; } // 010000
                if (rewardes >= 1) { return 8; } // 001000
                return 0; // 000
            }

            protected override void OnDestroy() {
#if UNITY_IOS
                if (this.ycManager.dataManager.GetDiffTimestamp() <= 60 * 60 * 24) {
                    this._tenjin.UpdateConversionValue(this.GetInters() + this.GetRewards());
                }
#endif
            }

            public override void SendEvent(string eventName) {
                if (this._tenjin) {
                    this._tenjin.SendEvent(eventName);
                }
            }

            public override void SetConsent(bool consent) {
                if (this._tenjin) {
                    if (consent) {
                        this._tenjin.OptIn();
                    } else {
                        this._tenjin.OptOut();
                    }
                }
            }

            private void OnApplicationPause(bool paused) {
                if (paused == false) {
                    this.Init();
                }
            }

        }
    }
}

