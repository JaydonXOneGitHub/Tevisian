#pragma once

namespace sf
{
	namespace Joystick
	{
        enum class Control
        {
            None,           //!< No control
            A,              //!< A / Cross button
            B,              //!< B / Circle button
            X,              //!< X / Square button
            Y,              //!< Y / Triangle button
            Back,           //!< Back / Select button
            Start,          //!< Start button
            Guide,          //!< Guilde / Home button
            Up,             //!< Directional pad, up direction
            Down,           //!< Directional pad, down direction
            Left,           //!< Directional pad, left direction
            Right,          //!< Directional pad, right direction
            LeftStick,      //!< Left stick pressed
            RightStick,     //!< Right stick pressed
            LeftShoulder,   //!< Left shoulder button
            RightShoulder,  //!< Right shoulder button
            LeftTrigger,    //!< Left trigger
            RightTrigger,   //!< Right trigger
            LeftXPlus,      //!< Left stick, X axis, positive direction
            LeftXMinus,     //!< Left stick, X axis, negative direction
            LeftYPlus,      //!< Left stick, Y axis, positive direction
            LeftYMinus,     //!< Left stick, Y axis, negative direction
            RightXPlus,     //!< Right stick, X axis, positive direction
            RightXMinus,    //!< Right stick, X axis, negative direction
            RightYPlus,     //!< Right stick, Y axis, positive direction
            RightYMinus,    //!< Right stick, Y axis, negative direction
            Touchpad,       //!< Touchpad (PS gamepads)
            Paddle1,        //!< Paddle 1
            Paddle2,        //!< Paddle 2
            Paddle3,        //!< Paddle 3
            Paddle4,        //!< Paddle 4
            Misc1           //!< Miscellaneous control #1
        };
	}
}