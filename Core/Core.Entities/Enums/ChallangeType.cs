using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum ChallangeType
    {
        MultiChoiseWithoutImage = 0,
        MultiChoiseWithImage = 1,
        MatchingPair = 2,
        VoiceWithArrange = 3,
        TranslateWithVoiceAndArrange = 4,
        CompleteTheSentence = 5,
        DragAndDrop = 6,
        CompleteTheWordFirst = 7 ,
        TrueOrFalse = 8,
        CompleteTheWordSecound = 9,
        CompleteTheWordThird = 10,
        Pattern = 11,
        Pairing = 12,


    }
}

