using UnityEngine;
using UnityEngine.SceneManagement;

namespace YsoCorp {
    namespace GameUtils {
        public class BaseManager : MonoBehaviour {

            private static YCManager YCMANAGER;

            public YCManager ycManager { get { return YCMANAGER; } private set { } }

            protected bool isQuitting = false;

            protected virtual void Awake() {
                if (this.IsInit() == false) {
                    foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects()) {
                        if (YCMANAGER == null) {
                            YCMANAGER = g.GetComponentInChildren<YCManager>(true);
                        }
                        if (this.IsInit()) {
                            return;
                        }
                    }
                }
            }

            bool IsInit() {
                return YCMANAGER != null;
            }

            protected virtual void OnApplicationQuit() {
                this.isQuitting = true;
            }

            protected virtual void OnDestroy() {
                if (this.isQuitting == false) {
                    this.OnDestroyNotQuitting();
                }
            }

            protected virtual void OnDestroyNotQuitting() { }
        }
    }
}
