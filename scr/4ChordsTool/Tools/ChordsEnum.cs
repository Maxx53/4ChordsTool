using System.ComponentModel.DataAnnotations;

namespace _4ChordsTool
{
    public enum ChordBase
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }

public enum ChordMod
    {
        [Display(Name = "5")]
        five,
        [Display(Name = "6")]
        six,
        [Display(Name = "7")]
        seven,
        [Display(Name = "7sus4")]
        sevenSus4,
        add9,
        m,
        m6,
        m7,
        maj,
        maj7,
        sus2,
        sus4
    }
}