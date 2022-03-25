using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppScenes //Clase que indica el nombre de las escenas.
{
    public static readonly string CUT_SCENE = "CUT_SCENE";

    public static readonly string MENU_SCENE = "MENU_SCENE";

    public static readonly string SESION_MONKEY = "SESION_MONKEY";

    public static readonly string SCENE_TRANSITION = "SCENE_TRANSITION";

    public static readonly string SESION_ORC_1 = "SESION_ORC_1";
    public static readonly string SESION_ORC_2 = "SESION_ORC_2";
    public static readonly string SESION_ORC_3 = "SESION_ORC_3";

    public static readonly string SESION_MUSKBOT_1 = "SESION_MUSKBOT_1";
    public static readonly string SESION_MUSKBOT_2 = "SESION_MUSKBOT_2";
    public static readonly string SESION_MUSKBOT_3 = "_";

    public static readonly string SESION_DND_1 = "SESION_DND_1";
    public static readonly string SESION_DND_2 = "SESION_DND_2";
    public static readonly string SESION_DND_3 = "SESION_DND_3";

    public static readonly string WEEK_1_ORGANIZATION = "BTW_Scene_W1";
    public static readonly string WEEK_2_ORGANIZATION = "BTW_Scene_W2";
    public static readonly string WEEK_3_ORGANIZATION = "BTW_Scene_W3";

    public static readonly string SCENE_SOSPECHA_MAX = "SCENE_SOSPECHA_MAX";
    public static readonly string SCENE_VICTORIA = "SCENE_VICTORIA";
}

public class AppAudio
{
    public static readonly string MUSIC_MENU = "MenuMusic - ChicaYeYe";
    public static readonly string MUSIC_BETWEEN_WEEKS = "BWMusic - Feelings";
    public static readonly string MUSIC_ORCS = "OrcSesionMusic - Rite of Pasage";
    public static readonly string MUSIC_MONKEY = "MonkeySesionMusic - Tiktopia";
    public static readonly string MUSIC_DND = "DNDSesionMusic - Pipin";
    public static readonly string MUSIC_MUSKBOT = "MuskBotSesionMusic - Anime";
    public static readonly string MUSIC_CUT_SCENE = "News Background Music";

    public static readonly string BUTTON_DIALOGUE_SFX = "Blop";
    public static readonly string BUTTON_NORMAL_SFX = "Click Button";
    public static readonly string BUTTON_CONFIRM_WEEK_SFX = "Rudy_rooster";

    public static readonly string SOUND_TAKE_POSSITS = "PageSound";
    public static readonly string SOUND_TAKE_OBJECT = "Blop";
    public static readonly string SOUND_LEFT_OBJECT = "StaplerPunch1";
    public static readonly string SOUND_ORC_1 = "Orc_02";
    public static readonly string SOUND_ORC_2 = "Orc_07";
    public static readonly string SOUND_ORC_3 = "Orc_45";
    public static readonly string SOUND_ORC_4 = "Orc_47";
    public static readonly string SOUND_HUMANO_BURRO_1 = "Human_Evil_00";
    public static readonly string SOUND_HUMANO_BURRO_2 = "Human_Evil_10";
    public static readonly string SOUND_HUMANO_BURRO_3 = "Human_Good_03";
    public static readonly string SOUND_HUMANO_BURRO_4 = "Human_Good_17";
    public static readonly string SOUND_ROBOT_1 = "Robot1_00";
    public static readonly string SOUND_ROBOT_2 = "Robot1_15";
    public static readonly string SOUND_ROBOT_3 = "Robot1_18";
    public static readonly string SOUND_ROBOT_4 = "Robot2_25";
    public static readonly string SOUND_DRAGON_1 = "Demon_05";
    public static readonly string SOUND_DRAGON_2 = "Demon_10";
    public static readonly string SOUND_DRAGON_3 = "Demon_15";
    public static readonly string SOUND_DRAGON_4 = "Demon_20";
    public static readonly string SOUND_MONKE_1 = "monkey1";
    public static readonly string SOUND_MONKE_2 = "monkey2";
    public static readonly string SOUND_MONKE_3 = "monkeypatas";
    public static readonly string SOUND_MONKE_4 = "rmonkeycolobus";
}

public class AppPlayerPrefKeys
{
    public static readonly string MUSIC_VOLUME = "MusicVolume";
    public static readonly string SFX_VOLUME = "SfxVolume";
}

public class AppPaths
{
    public static readonly string PATH_RESOURCE_SFX = "Sounds/Sfx/";
    public static readonly string PATH_RESOURCE_MUSIC = "Sounds/Music/";
}
