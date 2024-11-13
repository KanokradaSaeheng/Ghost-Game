# This file contains the code to style the "Dark Horror UI" theme correctly. You can copy this file into your own project's game folder. Remember to also include the fonts from the font's folder and all the necessary gui files.
# You will also need to adjust a small portion of code in your screens.rpy and gui.rpy files in your project. Please have a look at these files in this example project and search for the comments "CUSTOM CODE". Then change the code the same way in your own project's files.

## Custom font variables
define imfelldwpica = "fonts/IM Fell DW Pica/IMFellDWPica-Regular.ttf"
define imfelldwpicaitalic = "fonts/IM Fell DW Pica/IMFellDWPica-Italic.ttf"

## General Interface
# The font used for text for user interface elements, like the main and game menus, buttons, and so on.
define gui.interface_text_font = imfelldwpica
# The accent color is used in many places in the GUI, including titles and labels.
define gui.accent_color = '#ffffff'
# In-game text
define gui.text_font = imfelldwpica
# Color of dialogue text as well as other text displayables (like the sync screen in load/save menu's).
define gui.text_color = "#e4e4e4"
# General buttons
style button_text:
    font imfelldwpica
    idle_color "#ffffff"
    hover_color "#dedede"
    selected_color "#cccccc"

## Say/ADV-dialogue
style say_window xalign 0.5
style say_window ysize 337
style say_label font imfelldwpica
style say_label antialias True
style say_label hinting "bytecode"
style say_label color "#ffffff"
style say_label size 40
style say_label text_align 0.0
style say_dialogue size 28
style say_dialogue adjust_spacing True
style say_dialogue antialias True
style say_dialogue hinting "bytecode"
style say_dialogue color "#e4e4e4"

define gui.name_xpos = 0.25
define gui.name_ypos = 0.25
define gui.dialogue_xpos = 0.25
define gui.dialogue_ypos = 0.45
define gui.namebox_width = 1100
define gui.namebox_tile = True

# CTC (click-to-continue)
image ctc:
    "gui/ctc.png"
    offset(10, 5)
    easein 1.0 offset(10, 10)
    easein 1.0 offset(10, 5)
    repeat

## NVL dialogue
style nvl_window align (0.5, 0.5)
style nvl_window xsize 900
style nvl_label size 30
style nvl_label color "#ffffff"
style nvl_label yalign 0.0
style nvl_label font imfelldwpica
style nvl_label adjust_spacing True
style nvl_label antialias True
style nvl_label hinting "bytecode"
style nvl_dialogue size 25
style nvl_dialogue color "#e4e4e4"
style nvl_dialogue adjust_spacing True
style nvl_dialogue antialias True
style nvl_dialogue hinting "bytecode"
style nvl_dialogue yoffset 25

define gui.nvl_height = None
define gui.nvl_spacing = 30
define gui.nvl_borders = Borders(27, 140, 27, 140) # For padding the nvl window only.
define gui.nvl_name_xpos = 0.1
define gui.nvl_name_xalign = 0.0
define gui.nvl_text_xpos = 0.1
define gui.nvl_text_width = 700

## Quick menu
define gui.quick_button_text_font = imfelldwpica
define gui.quick_button_text_size = 25
style quick_button_text selected_color "#bfbfbf"

## Frames
define gui.frame_borders = Borders(20, 20, 20, 20)
define gui.frame_tile = True

## Confirm
style confirm_button hover_background Frame("gui/namebox.png", Borders(3, 0, 3, 20, 10, 0, 10, 0), tile = True)
style confirm_button ysize 40

## Choice buttons
style choice_button:
    right_margin 10
    left_padding 50
    right_padding 0
    top_padding 0
    bottom_padding 0
    ysize 40
    xmaximum 600
    xminimum 450

style choice_button_text:
    yalign 0.5
    xalign 0.0
    line_spacing -7
    hinting "bytecode"
    antialias True
    adjust_spacing True

style choice_vbox:
    anchor(0.0, 0.0)
    xalign 0.58
    yalign 0.95
    box_wrap True
    xsize 1100
    ysize 140

define gui.choice_button_borders = Borders(114, 7, 53, 8, 0, 0, 0, 0)
define gui.choice_button_tile = True
define gui.choice_button_text_font = imfelldwpica
define gui.choice_button_text_size = 25
define gui.choice_spacing = -2
define gui.choice_button_width = None
define gui.choice_button_text_idle_color = "#FFFFFF"
define gui.choice_button_text_hover_color = "#FFFFFF"
define gui.choice_button_text_insensitive_color = "#dedede"

## Notify
style notify_text font imfelldwpicaitalic
style notify_text antialias True
style notify_text size 26
style notify_text adjust_spacing True
style notify_text hinting "bytecode"
define gui.notify_frame_borders = Borders(0, 20, 20, 20, 30, 15, 15, 15)

## Skip
define gui.skip_frame_borders = Borders(0, 20, 20, 20, 30, 0, 0, 0)
style skip_text antialias True
style skip_text adjust_spacing True
style skip_text hinting "bytecode"
style skip_triangle line_spacing 0
style skip_triangle line_leading 0

## Game/Main Menu's
style main_menu_vbox:
    xalign 0.05
    yalign 0.1

style main_menu_title:
    size 50
    xsize 250
    text_align 0.5
    line_leading -10

style main_menu_version:
    text_align 0.5
    xalign 0.5

style main_menu_dev:
    text_align 0.5
    size 30
    pos(0.09, 0.95)
    anchor(0.5, 0.5)

# Navigation
style navigation_button:
    hover_left_margin 2

style navigation_button_text:
    idle_color "#ffffff"
    hover_color "#ffffff"
    font imfelldwpica
    size 40
    xalign 0.5

style game_menu_label_text font imfelldwpica

style game_menu_label:
    xalign 0.32
    yalign 0.05
    xanchor 0.0
    ysize 90
    xsize 1100
    top_padding 60
    bottom_padding 65
    left_padding 20
    right_padding 20

## Scrollbars
style vscrollbar:
    base_bar Frame("gui/scrollbar/vertical_[prefix_]bar.png", Borders(0, 0, 0, 0, 0, 0, 0, 0))
    thumb "gui/scrollbar/vertical_[prefix_]thumb.png"
    thumb_offset 6

style scrollbar:
    base_bar Frame("gui/scrollbar/horizontal_[prefix_]bar.png", Borders(19.5, 0, 19.5, 0, 0, 0, 0, 0))
    thumb "gui/scrollbar/horizontal_[prefix_]thumb.png"
    thumb_offset 19.5

define gui.scrollbar_size = 39

## Bars
define gui.bar_borders = Borders(2, 2, 2, 2)
define gui.vbar_borders = Borders(2, 2, 2, 2)

## Preferences
style pref_label_text font imfelldwpica
style radio_button_text font imfelldwpica
style radio_button_text line_leading -5
style radio_button left_padding 35
style check_button_text font imfelldwpica
style check_button_text line_leading -5
style check_button_text antialias True
style check_button left_padding 35

## Save/Load
style page_label yalign -0.07

## History
style history_text size 30
style history_name xsize 180
style history_name_text text_align 0.5
style history_name_text minwidth 180
style history_name_text size 30
style history_name_text left_padding 20
style history_window xfill False
style history_window ysize None
style history_window ymargin 20

define gui.history_height = None

# Return button
style return_button left_padding 50
style return_button top_padding 0
style return_button xalign 0.25
style return_button yalign 0.12
style return_button xsize 200
style return_button idle_background "gui/return_arrow_idle.png"
style return_button hover_background "gui/return_arrow_hover.png"
style return_button_text yalign 0.5
style return_button_text line_leading -12

## Sliders
style slider thumb_offset 6
style vslider thumb_offset 19.5

define gui.slider_borders = Borders(26, 0, 26, 0)
define gui.vslider_borders = Borders(0, 26, 0, 26)
define gui.slider_size = 39
