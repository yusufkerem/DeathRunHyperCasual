using UnityEngine;
using UnityEngine.UI;

namespace YsoCorp {
    namespace GameUtils {

        [DefaultExecutionOrder(-11)]
        public class SettingManager : BaseManager {

            private static Color COLOR_ON = Color.white;
            private static Color COLOR_OFF = new Color(0.7f, 0.7f, 0.7f, 1f);

            public Button bClose;
            public Button bRestorePurchase;
            public Button bDataPrivacy;
            public Button bSoundEffect;
            public Button bSoundMusic;
            public Button bVibration;
            public GameObject panelBts;
            public GameObject content;
            public Button bLang;

            protected override void Awake() {
                base.Awake();
                this.bSoundEffect.gameObject.SetActive(false);
                this.bSoundMusic.gameObject.SetActive(false);
                this.bVibration.gameObject.SetActive(false);
                this.bRestorePurchase.gameObject.SetActive(false);
                this.bLang.gameObject.SetActive(false);
            }

            private void Start() {
                if (this.ycManager.i18nManager.i18NResourcesManager.i18ns.Count > 1) {
                    this.bLang.gameObject.SetActive(true);
                    this.bLang.image.sprite = this.ycManager.i18nManager.GetCurrentStrite();
                    this.bLang.onClick.AddListener(() => {
                        this.ycManager.i18nManager.NextLanguages();
                        this.bLang.image.sprite = this.ycManager.i18nManager.GetCurrentStrite();
                    });
                }
                this.panelBts.gameObject.SetActive(
                    this.bSoundEffect.gameObject.activeSelf ||
                    this.bSoundMusic.gameObject.activeSelf ||
                    this.bVibration.gameObject.activeSelf ||
                    this.bLang.gameObject.activeSelf
                );
                this.bClose.onClick.AddListener(() => {
                    this.gameObject.SetActive(false);
                });
                this.bRestorePurchase.onClick.AddListener(() => {
                    //this.ycManager.inAppManager.RestorePurchases();
                });
                this.bDataPrivacy.onClick.AddListener(() => {
                    //this.ycManager.adsManager.DisplayGDPR();
                });
                this.bSoundEffect.onClick.AddListener(() => {
                    this.ycManager.dataManager.ToggleSoundEffect();
                    this.UpdateIHM();
                });
                this.bSoundMusic.onClick.AddListener(() => {
                    this.ycManager.dataManager.ToggleSoundMusic();
                    this.UpdateIHM();
                });
                this.UpdateIHM();
            }

            private void UpdateIHM() {
            }

            public void Show() {
                this.gameObject.SetActive(true);
            }

        }
    }
}