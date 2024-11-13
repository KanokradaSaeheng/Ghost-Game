# In this script file there's some example code to showcase the "Static Horror UI".
# Background image used is made by mugenjohncel on lemmasoft: https://lemmasoft.renai.us/forums/viewtopic.php?t=17302

define j = Character("James", ctc = "ctc")
define narrator = Character(who = None, what_xalign = 0.5, what_yalign = 0.4, what_italic = True, ctc = "ctc")

label park_night(do):
    scene background
    if do == "bins":
        j "I searched the bins and found a bloody note!"
    elif do == "playground":
        j "I searched the playground, but found nothing of interest."
    elif do == "talk":
        j "I went up and talked to a couple on a bench."

    call screen bar_test

screen bar_test:
    frame:
        xysize(630, 350)
        align(0.5, 0.5)
        text "Database retrieval 48% complete." align(0.5, 0.2)
        bar:
            value 48
            range 100
            xsize 500
            align(0.5, 0.5)
        textbutton "OK!" action Return() align(0.5, 0.8)

label start:
    scene background
    j "My investigations lead me to a park where Helen was last seen. The time was ticking, I needed to find out where she went before it was too late."
    j "I knew there would be clues left behind in the park. It was time to get digging."
    $renpy.notify("Find clues where Helen went.")
    menu:
        j "- What do you do?" (what_xpos = 0.315, what_ypos = 0.285)
        "Search bins":
            call park_night("bins")
        "Check playground":
            call park_night("playground")
        "Talk to park visitors":
            call park_night("talk")
    return
