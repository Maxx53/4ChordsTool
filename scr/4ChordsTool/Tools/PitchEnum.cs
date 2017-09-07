using System.ComponentModel.DataAnnotations;

namespace _4ChordsTool
{
    public enum Pitch
    {
        [Display(Name = "C-1")]
        CNeg1 = 0,

        [Display(Name = "C#-1")]
        CSharpNeg1 = 1,

        [Display(Name = "D-1")]
        DNeg1 = 2,

        [Display(Name = "D#-1")]
        DSharpNeg1 = 3,

        [Display(Name = "E-1")]
        ENeg1 = 4,

        [Display(Name = "F-1")]
        FNeg1 = 5,

        [Display(Name = "F#-1")]
        FSharpNeg1 = 6,

        [Display(Name = "G-1")]
        GNeg1 = 7,

        [Display(Name = "G#-1")]
        GSharpNeg1 = 8,

        [Display(Name = "A-1")]
        ANeg1 = 9,

        [Display(Name = "A#-1")]
        ASharpNeg1 = 10,

        [Display(Name = "B-1")]
        BNeg1 = 11,

        C0 = 12,

        [Display(Name = "C#0")]
        CSharp0 = 13,
        //
        // Сводка:
        //     D in octave 0.
        D0 = 14,

        [Display(Name = "D#0")]
        DSharp0 = 15,
        //
        // Сводка:
        //     E in octave 0.
        E0 = 16,
        //
        // Сводка:
        //     F in octave 0.
        F0 = 17,

        [Display(Name = "F#0")]
        FSharp0 = 18,
        //
        // Сводка:
        //     G in octave 0.
        G0 = 19,

        [Display(Name = "G#0")]
        GSharp0 = 20,
        //
        // Сводка:
        //     A in octave 0.
        A0 = 21,

        [Display(Name = "A#0")]
        ASharp0 = 22,
        //
        // Сводка:
        //     B in octave 0.
        B0 = 23,
        //
        // Сводка:
        //     C in octave 1.
        C1 = 24,

        [Display(Name = "C#1")]
        CSharp1 = 25,
        //
        // Сводка:
        //     D in octave 1.
        D1 = 26,

        [Display(Name = "D#1")]
        DSharp1 = 27,
        //
        // Сводка:
        //     E in octave 1.
        E1 = 28,
        //
        // Сводка:
        //     F in octave 1.
        F1 = 29,

        [Display(Name = "F#1")]
        FSharp1 = 30,
        //
        // Сводка:
        //     G in octave 1.
        G1 = 31,

        [Display(Name = "G#1")]
        GSharp1 = 32,
        //
        // Сводка:
        //     A in octave 1.
        A1 = 33,

        [Display(Name = "A#1")]
        ASharp1 = 34,
        //
        // Сводка:
        //     B in octave 1.
        B1 = 35,
        //
        // Сводка:
        //     C in octave 2.
        C2 = 36,

        [Display(Name = "C#2")]
        CSharp2 = 37,
        //
        // Сводка:
        //     D in octave 2.
        D2 = 38,

        [Display(Name = "D#2")]
        DSharp2 = 39,
        //
        // Сводка:
        //     E in octave 2.
        E2 = 40,
        //
        // Сводка:
        //     F in octave 2.
        F2 = 41,

        [Display(Name = "F#2")]
        FSharp2 = 42,
        //
        // Сводка:
        //     G in octave 2.
        G2 = 43,

        [Display(Name = "G#2")]
        GSharp2 = 44,
        //
        // Сводка:
        //     A in octave 2.
        A2 = 45,

        [Display(Name = "A#2")]
        ASharp2 = 46,
        //
        // Сводка:
        //     B in octave 2.
        B2 = 47,
        //
        // Сводка:
        //     C in octave 3.
        C3 = 48,

        [Display(Name = "C#3")]
        CSharp3 = 49,
        //
        // Сводка:
        //     D in octave 3.
        D3 = 50,

        [Display(Name = "D#3")]
        DSharp3 = 51,
        //
        // Сводка:
        //     E in octave 3.
        E3 = 52,
        //
        // Сводка:
        //     F in octave 3.
        F3 = 53,

        [Display(Name = "F#3")]
        FSharp3 = 54,
        //
        // Сводка:
        //     G in octave 3.
        G3 = 55,

        [Display(Name = "G#3")]
        GSharp3 = 56,
        //
        // Сводка:
        //     A in octave 3.
        A3 = 57,

        [Display(Name = "A#3")]
        ASharp3 = 58,
        //
        // Сводка:
        //     B in octave 3.
        B3 = 59,
        //
        // Сводка:
        //     C in octave 4, also known as Middle C.
        C4 = 60,

        [Display(Name = "C#4")]
        CSharp4 = 61,
        //
        // Сводка:
        //     D in octave 4.
        D4 = 62,

        [Display(Name = "D#4")]
        DSharp4 = 63,
        //
        // Сводка:
        //     E in octave 4.
        E4 = 64,
        //
        // Сводка:
        //     F in octave 4.
        F4 = 65,

        [Display(Name = "F#4")]
        FSharp4 = 66,
        //
        // Сводка:
        //     G in octave 4.
        G4 = 67,

        [Display(Name = "G#4")]
        GSharp4 = 68,
        //
        // Сводка:
        //     A in octave 4.
        A4 = 69,

        [Display(Name = "A#4")]
        ASharp4 = 70,
        //
        // Сводка:
        //     B in octave 4.
        B4 = 71,
        //
        // Сводка:
        //     C in octave 5.
        C5 = 72,

        [Display(Name = "C#5")]
        CSharp5 = 73,
        //
        // Сводка:
        //     D in octave 5.
        D5 = 74,

        [Display(Name = "D#5")]
        DSharp5 = 75,
        //
        // Сводка:
        //     E in octave 5.
        E5 = 76,
        //
        // Сводка:
        //     F in octave 5.
        F5 = 77,

        [Display(Name = "F#5")]
        FSharp5 = 78,
        //
        // Сводка:
        //     G in octave 5.
        G5 = 79,

        [Display(Name = "G#5")]
        GSharp5 = 80,
        //
        // Сводка:
        //     A in octave 5.
        A5 = 81,

        [Display(Name = "A#5")]
        ASharp5 = 82,
        //
        // Сводка:
        //     B in octave 5.
        B5 = 83,
        //
        // Сводка:
        //     C in octave 6.
        C6 = 84,

        [Display(Name = "C#6")]
        CSharp6 = 85,
        //
        // Сводка:
        //     D in octave 6.
        D6 = 86,

        [Display(Name = "D#6")]
        DSharp6 = 87,
        //
        // Сводка:
        //     E in octave 6.
        E6 = 88,
        //
        // Сводка:
        //     F in octave 6.
        F6 = 89,

        [Display(Name = "F#6")]
        FSharp6 = 90,
        //
        // Сводка:
        //     G in octave 6.
        G6 = 91,

        [Display(Name = "G#6")]
        GSharp6 = 92,
        //
        // Сводка:
        //     A in octave 6.
        A6 = 93,

        [Display(Name = "A#6")]
        ASharp6 = 94,
        //
        // Сводка:
        //     B in octave 6.
        B6 = 95,
        //
        // Сводка:
        //     C in octave 7.
        C7 = 96,

        [Display(Name = "C#7")]
        CSharp7 = 97,
        //
        // Сводка:
        //     D in octave 7.
        D7 = 98,

        [Display(Name = "D#7")]
        DSharp7 = 99,
        //
        // Сводка:
        //     E in octave 7.
        E7 = 100,
        //
        // Сводка:
        //     F in octave 7.
        F7 = 101,

        [Display(Name = "F#7")]
        FSharp7 = 102,
        //
        // Сводка:
        //     G in octave 7.
        G7 = 103,

        [Display(Name = "G#7")]
        GSharp7 = 104,
        //
        // Сводка:
        //     A in octave 7.
        A7 = 105,

        [Display(Name = "A#7")]
        ASharp7 = 106,
        //
        // Сводка:
        //     B in octave 7.
        B7 = 107,
        //
        // Сводка:
        //     C in octave 8, usually the highest key on an 88-key keyboard.
        C8 = 108,

        [Display(Name = "C#8")]
        CSharp8 = 109,
        //
        // Сводка:
        //     D in octave 8.
        D8 = 110,

        [Display(Name = "D#8")]
        DSharp8 = 111,
        //
        // Сводка:
        //     E in octave 8.
        E8 = 112,
        //
        // Сводка:
        //     F in octave 8.
        F8 = 113,

        [Display(Name = "F#8")]
        FSharp8 = 114,
        //
        // Сводка:
        //     G in octave 8.
        G8 = 115,

        [Display(Name = "G#8")]
        GSharp8 = 116,
        //
        // Сводка:
        //     A in octave 8.
        A8 = 117,

        [Display(Name = "A#8")]
        ASharp8 = 118,
        //
        // Сводка:
        //     B in octave 8.
        B8 = 119,
        //
        // Сводка:
        //     C in octave 9.
        C9 = 120,

        [Display(Name = "C#9")]
        CSharp9 = 121,
        //
        // Сводка:
        //     D in octave 9.
        D9 = 122,

        [Display(Name = "D#9")]
        DSharp9 = 123,
        //
        // Сводка:
        //     E in octave 9.
        E9 = 124,
        //
        // Сводка:
        //     F in octave 9.
        F9 = 125,

        [Display(Name = "F#9")]
        FSharp9 = 126,
        //
        // Сводка:
        //     G in octave 9.
        G9 = 127,

        //Mute
        z = 128,

        //Sustaining
        _ = 129,

        [Display(Name = "")]
        None = 130,
    }
}
