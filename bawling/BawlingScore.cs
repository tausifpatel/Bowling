using System;

namespace bawling
{
    public class BawlingScore
    {
        public double Calculate(string sequenceOfRolls)
        {
            double score = 0;
            double strikeScore = 10;
            double spareScore = 10;
            
            string[] frames = sequenceOfRolls.Split();
            var framesIndex = 0;

            foreach (var frame in frames)
            {
                var spare = frame.Contains("/");
                var strike = frame == "X";
                var isLastFrame = framesIndex+1 == frames.Length;

                if (!spare && !strike)
                {
                    foreach (char c in frame)
                    {
                        var num = Char.GetNumericValue(c);
                        score += num;
                    }     
                }

                if (spare && !isLastFrame)
                {
                    var followingFrame = frames[framesIndex + 1];
                    var followingFrameIsStrike = followingFrame == "X";

                    if (followingFrameIsStrike)
                    {
                        var total = spareScore + strikeScore;
                        score += total;
                    }
                    else
                    {
                        var firstRollFromFollowingFrame = Char.GetNumericValue(frames[framesIndex+1][0]);
                        var total = spareScore + firstRollFromFollowingFrame;
                        score += total;
                    }
                }
                
                if (strike && !isLastFrame)
                {
                    var followingFrame = frames[framesIndex + 1];
                    var followingFrameIsSpare = followingFrame.Contains("/");
                    var followingFrameIsStrike = followingFrame == "X";
                    double followingFrameScore = 0;

                    if (followingFrameIsSpare)
                    {
                        followingFrameScore += 10;
                    }

                    if (followingFrameIsStrike)
                    {
                        followingFrameScore += 10;
                    }

                    if (!followingFrameIsSpare && !followingFrameIsStrike)
                    {
                        foreach (var c in followingFrame)
                        {
                            var num = Char.GetNumericValue(c);
                            followingFrameScore += num;
                        }    
                    }
                    
                    var total = strikeScore + followingFrameScore;
                    score += total;
                }

                if (spare && isLastFrame)
                {
                    switch (frame[2])
                    {
                        case 'X':
                            score += spareScore + strikeScore;
                            break;
                        default:
                            score += spareScore + Char.GetNumericValue(frame[2]);
                            break;
                    }
                }
                
                if (strike && isLastFrame)
                {
                    switch (frame[1])
                    {
                        case 'X':
                            score += strikeScore * 2;
                            break;
                        default:
                            score += strikeScore + frame[1];
                            break;
                    }
                    
                    score += strikeScore;
                }

                framesIndex++;
            }
            
            return score;
        }
    }
}