=== ink_chest_open ===
text #loc:chest_open_suspense #speaker:system
~ SetCurrentChestItemAsArgument()
~ PlaySfx("sfx-chest_open")
text #loc:chest_found #speaker:system
~ ClearArguments()
-> DONE
