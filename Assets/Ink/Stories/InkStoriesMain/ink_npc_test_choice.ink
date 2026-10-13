=== ink_npc_test_choice ===
text #loc:greeting_hello_default_male #speaker:npc:npc-00000-test:default
+ choice #loc:choice_about_you #speaker:npc:npc-00000-test:default
    text #loc:dialog_test_0 #speaker:npc:npc-00000-test:default
    -> ink_npc_test_choice
+ choice #loc:choice_about_place #speaker:npc:npc-00000-test:default
    text #loc:dialog_test_1 #speaker:npc:npc-00000-test:default
    text #loc:dialog_test_0 #speaker:npc:npc-00000-test:default
    -> ink_npc_test_choice
+ choice #loc:choice_match #speaker:npc:npc-00000-test:default
    text #loc:dialog_test_1 #speaker:npc:npc-00000-test:default
    ~ OpenSubmenuTest("test_id")
    text #loc:dialog_test_0 #speaker:npc:npc-00000-test:default
    -> ink_npc_test_choice
+ choice #loc:choice_goodbye #speaker:npc:npc-00000-test:default
    text #loc:farewell_goodbye_default_male #speaker:npc:npc-00000-test:default
    -> DONE
