﻿namespace EOLib.Localization
{
    /// <summary>
    /// Constants for resource string status messages in the second data file for the language
    /// </summary>
    public enum EOResourceID
    {
        //these are status labels, and dialog text for non-alert style dialogs

        //mouseover status label strings for buttons
        STATUS_LABEL_HUD_BUTTON_HOVER_FIRST = 3,
        STATUS_LABEL_HUD_BUTTON_HOVER_LAST = 13,


        YOUR_MIND_PREVENTS_YOU_TO_SAY = 14,
        STATUS_LABEL_INVALID_INPUT_TRY = 15,
        STATUS_LABEL_CHAT_PANEL_NOW_VIEWED = 16,
        STATUS_LABEL_STATS_PANEL_NOW_VIEWED = 17,
        STATUS_LABEL_ONLINE_PLAYERS_NOW_VIEWED = 18,
        STATUS_LABEL_WILL_BE_IGNORED = 19,

        STATUS_LABEL_PARTY_IS_INVITED = 21,

        STATUS_LABEL_PARTY_REQUESTED_TO_JOIN = 23,

        STATUS_LABEL_MENU_BELONGS_TO_PLAYER = 26,
        STATUS_LABEL_PARTY_RECENTLY_REQUESTED = 27,
        STATUS_LABEL_NOT_READY_TO_USE_ENTRANCE = 28,
        STATUS_LABEL_PARTY_IS_ALREADY_MEMBER = 29,
        SYS_CHAT_PM_PLAYER_COULD_NOT_BE_FOUND = 30,
        STATUS_LABEL_YOU_ENTERED = 31,

        STATUS_LABEL_PARTY_YOU_JOINED = 33,
        STATUS_LABEL_PARTY_JOINED_YOUR = 34,

        STATUS_LABEL_PARTY_LEFT_YOUR = 36,
        STATUS_LABEL_TYPE_BUTTON = 37,
        STATUS_LABEL_TYPE_ACTION = 38,
        STATUS_LABEL_TYPE_WARNING = 39,
        STATUS_LABEL_TYPE_INFORMATION = 40,

        SETTING_ENABLED = 43,
        SETTING_DISABLED = 44,
        SETTING_NORMAL = 45,
        SETTING_EXCLUSIVE = 46,
        SETTING_LANG_CURRENT = 47,
        //48 - 49 match 47 in each localized file (which is language of curr file)
        SETTING_LANG_AZERTY = 50, //this is AZERTY in each file

        STATUS_LABEL_INVENTORY_DROP_BUTTON = 51,
        STATUS_LABEL_INVENTORY_JUNK_BUTTON = 52,
        STATUS_LABEL_SETTINGS_CLICK_TO_CHANGE = 53,
        STATUS_LABEL_TYPE_ITEM = 54,
        DIALOG_TRANSFER_HOW_MUCH = 55,
        DIALOG_TRANSFER_DROP = 56,
        DIALOG_TRANSFER_JUNK = 57,
        DIALOG_TRANSFER_GIVE = 58,
        STATUS_LABEL_ITEM_DROP_YOU_DROPPED = 59,
        STATUS_LABEL_ITEM_JUNK_YOU_JUNKED = 60,
        STATUS_LABEL_ITEM_PICKUP_YOU_PICKED_UP = 61,
        STATUS_LABEL_YOU_HAVE_NO_MORE = 62,
        STATUS_LABEL_ITEM_PICKUP_NO_SPACE_LEFT = 63,
        STATUS_LABEL_PAPERDOLL_HAT_EQUIPMENT = 64,
        STATUS_LABEL_PAPERDOLL_NECKLACE_EQUIPMENT = 65,
        STATUS_LABEL_PAPERDOLL_ARMOR_EQUIPMENT = 66,
        STATUS_LABEL_PAPERDOLL_WEAPON_EQUIPMENT = 67,
        STATUS_LABEL_PAPERDOLL_SHIELD_EQUIPMENT = 68,
        STATUS_LABEL_PAPERDOLL_BELT_EQUIPMENT = 69,
        STATUS_LABEL_PAPERDOLL_RING_EQUIPMENT = 70,
        STATUS_LABEL_PAPERDOLL_ARMLET_EQUIPMENT = 71,
        STATUS_LABEL_PAPERDOLL_BRACER_EQUIPMENT = 72,
        STATUS_LABEL_PAPERDOLL_GLOVES_EQUIPMENT = 73,
        STATUS_LABEL_PAPERDOLL_BOOTS_EQUIPMENT = 74,
        STATUS_LABEL_PAPERDOLL_MISC_EQUIPMENT = 75,
        STATUS_LABEL_ITEM_DROP_OUT_OF_RANGE = 76,
        STATUS_LABEL_INVENTORY_SHOW_YOUR_PAPERDOLL = 77,

        STATUS_LABEL_ITEM_EQUIP_DOES_NOT_FIT_GENDER = 79,
        STATUS_LABEL_ITEM_EQUIP_TYPE_ALREADY_EQUIPPED = 80,
        STATUS_LABEL_ITEM_UNEQUIP_NO_SPACE_LEFT = 81,

        CHAT_MESSAGE_MUTED_BY = 83,
        STATUS_LABEL_MINUTES_MUTED = 84,
        DIALOG_ITS_TOO_HEAVY_WEIGHT = 85,
        STATUS_LABEL_YOU_GAINED_EXP = 86,
        STATUS_LABEL_ITEM_PICKUP_PROTECTED = 87,
        STATUS_LABEL_ITEM_PICKUP_PROTECTED_BY = 88,
        STATUS_LABEL_NO_MAP_OF_AREA = 89,
        STATUS_LABEL_ITEM_USE_DRUNK = 90,

        STATUS_LABEL_CHEST_YOU_OPENED = 92,

        STATUS_LABEL_TRADE_REQUESTED_TO_TRADE = 96,
        STATUS_LABEL_TRADE_RECENTLY_REQUESTED = 97,
        STATUS_LABEL_TRADE_YOU_ARE_TRADING_WITH = 98,
        STATUS_LABEL_TRADE_OTHER_ACCEPT = 99,
        STATUS_LABEL_TRADE_YOU_ACCEPT = 100,
        STATUS_LABEL_TRADE_OTHER_CANCEL = 101,
        STATUS_LABEL_TRADE_YOU_CANCEL = 102,
        STATUS_LABEL_TRADE_ABORTED = 103,
        DIALOG_TRADE_WORD_AGREE = 104,
        DIALOG_TRADE_WORD_TRADING = 105,
        DIALOG_TRANSFER_OFFER = 106,
        DIALOG_TRANSFER_NOT_ENOUGH_SPACE = 107,
        DIALOG_TRANSFER_NOT_ENOUGH_WEIGHT = 108,
        STATUS_LABEL_TRADE_OTHER_PLAYER_CHANGED_OFFER = 109,
        //STATUS_LABEL_CHEST_YOU_OPENED = 110, //duplicate of 92?
        //chest seems broken - not sure when this is used
        //door seems broken - not sure when this is used
        STATUS_LABEL_THE_CHEST_IS_LOCKED_EXCLAMATION = 113,
        STATUS_LABEL_THE_DOOR_IS_LOCKED_EXCLAMATION = 114,
        STATUS_LABEL_DRAG_AND_DROP_ITEMS = 115,

        STRING_SERVER = 118,
        SERVER_MESSAGE_MAP_MUTATION = 119,
        STATUS_LABEL_NOTHING_HAPPENED = 120,
        YOU_CANNOT_ATTACK_THIS_NPC = 121,
        DIALOG_SHOP_BUY_ITEMS = 122,
        DIALOG_SHOP_SELL_ITEMS = 123,
        DIALOG_SHOP_CRAFT_ITEMS = 124,
        DIALOG_BANK_WITHDRAW = 125,
        DIALOG_BANK_DEPOSIT = 126,
        DIALOG_SHOP_PRICE = 127,
        MALE = 128,
        FEMALE = 129,
        DIALOG_TRANSFER_BUY = 130,
        DIALOG_TRANSFER_SELL = 131,
        DIALOG_TRANSFER_WITHDRAW = 132,
        DIALOG_TRANSFER_DEPOSIT = 133,
        DIALOG_SHOP_ITEMS_IN_STORE = 134,
        DIALOG_SHOP_ITEMS_ACCEPTED = 135,
        DIALOG_BANK_TAKE = 136,
        DIALOG_BANK_FROM_ACCOUNT = 137,
        DIALOG_BANK_TRANSFER = 138,
        DIALOG_BANK_TO_ACCOUNT = 139,
        DIALOG_WORD_BUY = 140,
        DIALOG_WORD_SELL = 141,
        DIALOG_WORD_FOR = 142,
        STATUS_LABEL_YOU_SOLD = 143,
        STATUS_LABEL_YOU_BOUGHT = 144,
        DIALOG_TITLE_PRIVATE_LOCKER = 145,

        STATUS_LABEL_IGNORE_LIST = 149,
        STATUS_LABEL_FRIEND_LIST = 150,
        STATUS_LABEL_USE_RIGHT_MOUSE_CLICK_DELETE = 151,
        GLOBAL_CHAT_SERVER_MESSAGE_1 = 152,
        GLOBAL_CHAT_SERVER_MESSAGE_2 = 153,
        STATUS_LABEL_WILL_BE_YOUR_FRIEND = 154,
        DIALOG_WHO_TO_MAKE_IGNORE = 155,
        DIALOG_WHO_TO_MAKE_FRIEND = 156,
        DIALOG_SHOP_CRAFT_INGREDIENTS = 157,
        DIALOG_SHOP_CRAFT_MISSING_INGREDIENTS = 158,
        DIALOG_SHOP_CRAFT_PUT_INGREDIENTS_TOGETHER = 159,

        DIALOG_WORD_CURRENT = 163,

        DIALOG_TRADE_BOTH_PLAYERS_OFFER_ONE_ITEM = 165,

        DIALOG_TRANSFER_TRANSFER = 176,

        SETTING_KEYBOARD_ENGLISH = 253,
        SETTING_KEYBOARD_DUTCH = 254,
        SETTING_KEYBOARD_SWEDISH = 255,
        SETTING_KEYBOARD_AZERTY = 256,

        BOARD_TOWN_BOARD = 271,
        BOARD_TOWN_BOARD_NOW_VIEWED = 272,
        BOARD_LOADING_MESSAGE = 273,
        BOARD_POSTING_NEW_MESSAGE = 274,

        JAIL_WARNING_CANNOT_DROP_ITEMS = 275,
        JAIL_WARNING_CANNOT_TRADE = 276,
        JAIL_WARNING_CANNOT_USE_GLOBAL = 277,

        STATUS_LABEL_KEEP_MOVING_THROUGH_PLAYER = 278,

        JUKEBOX_NOW_VIEWED = 279,
        JUKEBOX_BROWSE_THROUGH_SONGS = 280,
        JUKEBOX_PLAY_SONG = 281,
        JUKEBOX_REQUEST_SONG = 282,
        JUKEBOX_REQUEST_SONG_FOR = 283,
        JUKEBOX_PLAYING_REQUEST = 284,
        JUKEBOX_IS_READY = 285,

        DIALOG_TITLE_PERFORMANCE = 286,
        DIALOG_PERFORMANCE_TOTALEXP = 287,
        DIALOG_PERFORMANCE_NEXT_LEVEL = 288,
        DIALOG_PERFORMANCE_EXP_NEEDED = 289,
        DIALOG_PERFORMANCE_TODAY_EXP = 290,
        DIALOG_PERFORMANCE_TOTAL_AVG = 291,
        DIALOG_PERFORMANCE_TODAY_AVG = 292,
        DIALOG_PERFORMANCE_BEST_KILL = 293,
        DIALOG_PERFORMANCE_LAST_KILL = 294,

        IDLE_TOO_LONG = 295,
        IDLE_PLEASE_START_MOVING = 296,

        SKILLMASTER_WORD_SPELL = 297,
        SKILLMASTER_WORD_SKILL = 298,
        SPELL_WAS_SELECTED = 299,
        SPELL_NOTHING_WAS_SELECTED = 300,

        ATTACK_YOU_ARE_EXHAUSTED_TP = 302,
        ATTACK_YOU_ARE_EXHAUSTED_SP = 303,
        SPELL_ONLY_WORKS_ON_GROUP = 304,
        STATUS_LABEL_THE_NPC_DROPPED = 305,

        YOU_HAVE_BEEN_FROZEN = 306,

        REBOOT_SERVER_REBOOTING = 307,
        REBOOT_SEQUENCE_STARTED = 308,

        //ARENA_EVENT_ABORTED_LAST_OPPONENT_DC = 309, // not used
        ARENA_ROUND_DELAYED_STILL_PLAYERS = 310,
        ARENA_WON_EVENT = 311,
        ARENA_PLAYERS_LAUNCHED = 312,
        ARENA_WAS_ELIMINATED_BY = 313,
        ARENA_KILLED = 314,
        ARENA_PLAYERS = 315,
        ARENA_DO_NOT_BLOCK_LINE = 316,
        ARENA_PLEASE_MOVE_FROM_PLACE = 317,

        WEDDING_PLEASE_ENTER_NAME = 318,
        WEDDING_IS_ASKING_YOU_TO_MARRY = 319,
        WEDDING_REGISTRATION_SERVICE = 320,
        WEDDING_REQUEST_MARRIAGE_OR_DIVORCE = 321,
        WEDDING_MARRIAGE = 322,
        WEDDING_REQUEST_WEDDING_APPROVAL = 323,
        WEDDING_DIVORCE = 324,
        WEDDING_BREAK_UP = 325,
        WEDDING_REQUEST_TEXT_1 = 326,
        WEDDING_REQUEST_TEXT_2 = 327,
        WEDDING_REQUEST_TEXT_LINK = 328,
        WEDDING_DIVORCE_TEXT_1 = 329,
        WEDDING_DIVORCE_TEXT_2 = 330,
        WEDDING_DIVORCE_TEXT_LINK = 331,
        WEDDING_PROMPT_ENTER_NAME_MARRY = 332,
        WEDDING_PROMPT_ENTER_NAME_DIVORCE = 333,

        SKILLMASTER_WORD_LEARN = 334,
        SKILLMASTER_ITEMS_TO_LEARN = 335,
        SKILLMASTER_WORD_FORGET = 336,
        SKILLMASTER_ITEMS_LEARNED = 337,
        SKILLMASTER_WORD_REQUIREMENTS = 338,
        SKILLMASTER_WORD_LEVEL = 339,
        SKILLMASTER_WORD_STRENGTH = 340,
        SKILLMASTER_WORD_INTELLIGENCE = 341,
        SKILLMASTER_WORD_WISDOM = 342,
        SKILLMASTER_WORD_AGILITY = 343,
        SKILLMASTER_WORD_CONSTITUTION = 344,
        SKILLMASTER_WORD_CHARISMA = 345,
        STATUS_LABEL_CANNOT_ATTACK_OVERWEIGHT = 346,
        SKILLMASTER_FORGET_ALL = 347,
        SKILLMASTER_FORGET_ALL_MSG_1 = 348,
        SKILLMASTER_FORGET_ALL_MSG_2 = 349,
        SKILLMASTER_FORGET_ALL_MSG_3 = 350,
        SKILLMASTER_CLICK_HERE_TO_FORGET_ALL = 351,
        SKILLMASTER_RESET_YOUR_CHARACTER = 352,

        ACCOUNT_CREATE_WARNING_DIALOG_1 = 357,
        ACCOUNT_CREATE_WARNING_DIALOG_2 = 358,
        ACCOUNT_CREATE_WARNING_DIALOG_3 = 359,
        LOADING_GAME_UPDATING_MAP = 360,
        LOADING_GAME_UPDATING_ITEMS = 361,
        LOADING_GAME_UPDATING_NPCS = 362,
        LOADING_GAME_UPDATING_SKILLS = 363,
        LOADING_GAME_UPDATING_CLASSES = 364,
        LOADING_GAME_UPDATING_GUILDS = 365,
        LOADING_GAME_LOADING_GAME = 366,
        LOADING_GAME_PLEASE_WAIT = 367,
        LOADING_GAME_HINT_FIRST = 368,
        LOADING_GAME_HINT_LAST = 374,

        ENDLESS_HELP = 375,
        ENDLESS_HELP_SUMMARY_1 = 376,
        ENDLESS_HELP_SUMMARY_2 = 377,

        ENDLESS_HELP_LINK_RESET_PASSWORD = 378,
        ENDLESS_HELP_LINK_REPORT_SOMEONE = 379,
        ENDLESS_HELP_LINK_SPEAK_TO_ADMIN = 380,

        INN_REGISTRATION_SERVICE = 384,
        INN_CITIZEN_REGISTRATION_SERVICE = 385,
        INN_SIGN_UP = 386,
        INN_BECOME_A_CITIZEN = 387,
        INN_UNSUBSCRIBE = 388,
        INN_GIVE_UP_CITIZENSHIP = 389,
        INN_BECOME_CITIZEN_TEXT_1 = 390,
        INN_BECOME_CITIZEN_TEXT_2 = 391,
        INN_BECOME_CITIZEN_TEXT_LINK = 392,
        INN_GIVE_UP_TEXT_1 = 393,
        INN_GIVE_UP_TEXT_LINK = 394,
        INN_BECOME_CITIZEN_CONGRATULATIONS = 395,
        INN_YOUR_ANSWERS_WERE_INCORRECT = 396,
        INN_YOU_ARE_NOT_A_CITIZEN = 397,
        INN_YOU_ARE_NO_LONGER_A_CITIZEN = 398,
        INN_SLEEP = 399,
        INN_FULL_HP_RECOVERY = 400,
        INN_A_GOOD_NIGHT_REST_WILL_COST_YOU = 401,

        YOUR_ATTACK_DID_NOTHING = 402, // ?

        INN_YOU_ARE_ALREADY_A_CITIZEN_OF_A_TOWN = 403,

        STATUS_LABEL_ITEM_EQUIP_CAN_ONLY_BE_USED_BY = 404,
        QUEST_PROGRESS = 405,
        QUEST_DID_NOT_START_ANY = 406,
        QUEST_HISTORY = 407,
        QUEST_COMPLETED = 408,
        QUEST_DID_NOT_FINISH_ANY = 409,

        STATUS_LABEL_ITEM_EQUIP_THIS_ITEM_REQUIRES = 411,

        STATUS_LABEL_UNABLE_TO_ATTACK = 423,
        STATUS_LABEL_YOU_HAVE_NO_ARROWS = 424,

        CAUTION_THIS_IS_A_PK_ZONE = 425,
        YOU_CANNOT_ATTACK_OTHER_PLAYERS_IN_THIS_ZONE = 426,

        STATUS_LABEL_YOUR_LOCATION_IS_AT = 427,
        STATUS_LABEL_IS_ONLINE_IN_THIS_WORLD = 428,
        STATUS_LABEL_IS_ONLINE_SAME_MAP = 429,
        STATUS_LABEL_IS_ONLINE_NOT_FOUND = 430,
        DIALOG_BANK_LOCKER_UPGRADE = 431,
        DIALOG_BANK_MORE_SPACE = 432,
        STATUS_LABEL_LOCKER_SPACE_INCREASED = 433
    }
}
