PACKAGE=start

VERSION=1.8.3
DATE=2021-05-18

================================================================================ VERSION 1.8.3
Bug multiscene YcManager

================================================================================ VERSION 1.8.2
Can Build IOS without module

================================================================================ VERSION 1.8.1
Bug FB

================================================================================ VERSION 1.8.0
Update Max
Update FB 9.2.0
Remove consent flow on start

================================================================================ VERSION 1.7.2
Bug setting
Bug build android
Update Max

================================================================================ VERSION 1.7.1
Bug notification

================================================================================ VERSION 1.7.0
Update Max
Enable ATT
Analytics add app_tracking_status session
Analytics add push_notif_status session

================================================================================ VERSION 1.6.1
Bug PushNotification
Update FB
Update Max

================================================================================ VERSION 1.6.0
Add PushNotification
[EXT] Array RemoveAt

================================================================================ VERSION 1.5.0
Smatter setting FB
Smatter setting MAX
Move script
Add BannerDisplayOnInit in YcConfig
Add More Analytics infos :
public class AppData {
    ...
    public string device_model;
    public string device_os_version;
    public int device_memory_size;
    public int device_processor_count;
    public int device_processor_frequency;
    public string device_processor_type;
    public SessionData session = {
        ...
        public int fps;
    }
    public Dictionary<string, int> events = {
        ...
        banner_show = 0;
        banner_click = 0;
    }
}

================================================================================ VERSION 1.4.5
Update MAX Bug

================================================================================ VERSION 1.4.4
Update MAX

================================================================================ VERSION 1.4.3
Remove Asking Tracking link Tenjin
Review Design Buttons

================================================================================ VERSION 1.4.2
Desable Consent Flow IOS 14
Move _.gitgnore into Assets
Update MAX

================================================================================ VERSION 1.4.1
Add OpenKeyboard in YCBehaviour
Add Object and Array in ADataManager
Add DuplicateReadable in YcTexture2DExtensions
Update MAX
Add Default _.gitgnore (remove _ when import)

================================================================================ VERSION 1.4.0
Change workflow Max for IOS 14
Change workflow Tenjin for IOS 14
Check if google exist before check AdMobIds

================================================================================ VERSION 1.3.1
BUG compilation when InApp Purchase Not Activate

================================================================================ VERSION 1.3.0
Add Default Workflow Maps
Add Shortcuts a, z, w, l
InApp Purchases only activate if service activate
Review Template (Menu Win, Menu Lose)