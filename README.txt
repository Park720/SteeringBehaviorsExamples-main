Steering Tag
 

Assignment Goals
In this assignment you will add and tune steering behaviors on an autonomously moving sphere.
You must use the images provided.

Assignment Description and Rationale
The goals of this assignment are to get experience in what is possible with steering behaviors and to start developing an intuitive sense for tweaking them.

My initial approach to this assignment was to simply add the existing steering behaviors (Persue, Evade, ObstacleAvoider) to the Player and tune the parameters to get the desired behavior.
I explored the different behaviors provided and found that some were similar to each other. For example, Flee and Seek are simpler versions of Evade and Persue. I decided to focus on Persue and Evade because they are more dynamic and interactive — since the opponents are always wandering around the scene, predicting their future position makes more sense than just chasing their current position.
When I added the behaviors, however, the sphere was not moving as expected. It was just wandering around the scene with the flock instead of actively pursuing or evading. No matter how much I tuned the parameters, the fundamental behavior didn't change.
After looking through the code, I found that there was no logic to decide when to pursue and when to evade, or who the target should be. The Steering Behaviors only calculate forces given a target — they had no way of knowing the game state.
Then I saw the announcement about the assignment mentioning that we may code on the first level of the autonomous action model.
So I made PlayerPlanning.cs act as the decision-making layer — observing isIt and directing the Steering Behaviors below it accordingly
After planning was done, I tuned the parameters of the behaviors to get the ideal behavior. 
I had to test out several times to find the right balance of parameters.
For Steering Object, Max force had to be adjusted since the player bounced off if the value was too high and the player failed to evade if the max velocity was too low.
For Persue, the prediction window had to be adjusted. I started from 5 and went lower until 1 since the player hesitated and wandered if the prediction window was too high. After changing to 1, the player pursued directly towards the target.
For Evade, I adjusted the prediction window but in the other way. I wanted the player to predict the opponent's movement as much as possible so that it can prepare the evade much sooner. However, this also did create some wandering issues.
I tried including obstacle avoider since the player tends to stick to walls but I failed to do so since I would have to change more which I thought would be against the instruction. So I had to leave that out.
Finally, the game was originally set for 15 seconds. However, since the instruction mentioned that it should go for 60 seconds, I changed that number in the TagPlayer component.
