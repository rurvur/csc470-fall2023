## Rhys Cabot's CSC-470 Final Project Design Document

- NAME - C.O.W. Game (Completely Overpowered Wizard Game)
- Genre: Top-down Action Roguelike
- Completion Date: December 14th (I have two other finals due on the 15th, so I'll plan to have this ready by the midnight after the 14th.)

## REQUIRED MECHANICS:
- Enemies spawning in progressively more dangerous waves
- A top down perspective
- Real time combat using a varying set of spells
- Gain EXP when defeating enemies to gain more spells and increase base stats
- Get gold on enemy kills to spend in shop locations on the map for items that increase stats

## TARGETS:
- Randomize spells gained on level up
- Randomize items from the shop
- "Elite" enemies that can spawn when wave count gets to a cetain benchmark, like in Risk of Rain
- Final Boss & Victory screen, option to continue the run
- Quicker restart so the game does not need to close and be reopened to play again after losing

## STRETCH GOALS:
- Rest period between waves to "spend" EXP on items
- Allow players to choose from a variety of primary spells (Fireball, Thunderwave, Icicle Slash)
- Multiple playable characters, with slightly different base stats (More speed, higher damage, lower health, etc.)
- Enemies that fire projectiles instead of varying speed
- Knockback and varying knockback resistance
- Alternate control schemes
- Items that spawn allies to help fight and can be targeted by enemies
- Pause Menu


## DESCRIPTION:
C.O.W. Game is a game where you play as a cow with a wizard hat that grants them the ability to cast spells and attract hostile farm animals. The player will be able to move with WASD in the Top-down
3D space an attack varying enemies. They can gather EXP and money to beome stronger after defeating other animals, and can return to their barn to exchange their money for items. The waves will get
progressively harder, with more animals being sent each time, which will also help with leveling up faster.

## INPUTS:
- WASD - Move (Either tank controls with W&S to move and S&D to turn, or full directional movement, with turning handled by raycasting to the mouse. Not sure which yet, likely the former.)
- P - Primary spell
- O - Secondary spell (Medium cooldown, bouncing lightning bolt?)
- I - Tertiary spell (Long cooldown, acid pool?)
- SHIFT - Utility spell (Maybe a barrier?)
- SPACE - Movement spell (Jump that creates a shockwave on landing?)
- E - Spend money
- LEFTMOUSEBUTTON - Menu navigation
- ESCAPE - Pause

## Timeline:
- December 1st - Complete Design Document (Complete)
- December 2nd - Title Screen, menu system
- December 5th - Working character model & input reading, mo(oo)vement
- December 9th - EnemyPrefab complete, waves working, at least 2 working spells
- December 11th - Leveling, gold, shop, and damage all working as intended