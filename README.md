# Bowling

Create a program, which, given a valid sequence of rolls for one line of American Ten-Pin Bowling, produces the total score for the game.

- The input is a valid sequence of rolls
- The output is the resulting score

## Example input
For instance, for a game that is partway through, your input might be:

### “X 45 4/ 32”

This indicates that:

- Four frames have been played
- The first frame was a “strike” (all 10 pins knocked over in one roll - symbolised by “X”)
- The second frame (“45”) consisted of the maximum two rolls
    - The first roll knocked down 4 pins
    - The second roll knocked down 5 pins
- The third frame was a “spare” (all 10 pins knocked down in two rolls - symbolised by “/” on the second roll)
    - The first roll knocked down 4 pins
    - The second roll knocked down the remaining 6 pins
- The fourth frame (“32”) consisted of two rolls
    - The first roll knocked down 3 pins
    - The second roll knocked down 2 pins

### Example output

For the above input of “X 45 4/ 32”, the score would be 46 - scored as follows:

- The first frame is a strike, which scores 10 + (all rolls from the following frame) = 10 + 4 + 5 = 19
- The second frame scores 4 + 5 = 9
- The third frame is a spare, which scores 10 + (the first roll from the following frame) = 10 + 3 = 13
- The fourth frame scores 3 + 2 = 5
