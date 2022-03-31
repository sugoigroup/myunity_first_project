using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;
using System;
using System.Collections;

namespace DefaultNamespace.data.local.staticlao
{
    public class ScoreStaticLao : StaticLao<Score>
    {
        private static List<Score> _scores = new List<Score>();
        private int _gameObjectId ;
        private int _stageNum  ;

        public ScoreStaticLao(int gameObjectId, int stageNum)
        {
            _gameObjectId =  gameObjectId;
            _stageNum = stageNum;
        }
        
        public void save(Score newValue)
        {
            // Effective C# Item1 지역변수는 var로 받아야 빠름. 단, float이나 double은 명시적으로 하는게 좋음.
            var score = _scores.FirstOrDefault(x => isEqualGameIdAndStageNum(x));
            if (score == null)
            {
                _scores.Add(newValue);
            }
            else
            {
                score.currentValue = newValue.currentValue;
            }
        }

        private bool isEqualGameIdAndStageNum(Score x)
        {
            return x.gameObjectId == _gameObjectId && x.stageNum == _stageNum;
        }


        public Score fetchOrNull()
        {
            return _scores.FirstOrDefault(x => isEqualGameIdAndStageNum(x));
        }

        public void remove()
        {
            _scores.Remove(
                _scores.FirstOrDefault(x => isEqualGameIdAndStageNum(x))
            );
        }
    }
}