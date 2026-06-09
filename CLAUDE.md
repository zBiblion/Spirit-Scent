❯ # CLAUDE.md - Spirit Scent                                                                                    
                                                                                                                
  ## Project Overview                                                                                           
  Game Name Spirit Scent                                                                                        
  Genre 3D Puzzle-Stealth Platformer with strong emotional narrative                                            
  Perspective God View (Top-down  Third Person Camera)                                                          
  Unity Version Unity 6                                                                                         
  Style Beautiful, emotional, atmospheric                                                                       
                                                                                                                
  Core Fantasy                                                                                                  
  Player is a spiritangel guiding a white dog through dangerous areas back to its hospitalized owner using      
  scent-based abilities.                                                                                        
                                                                                                                
  ---                                                                                                           
                                                                                                                
  ## Current Focus (Right Now)                                                                                  
                                                                                                                
  ### Interaction System & Puzzle Mechanics Needed                                                              
                                                                                                                
  1. Door (Slide  Open)                                                                                         
  - Can be opened by lever, button, or other systems                                                            
  - Should support smooth openclose animation                                                                   
  - Needs public methods `OpenDoor()`, `CloseDoor()`, `ToggleDoor()`                                            
                                                                                                                
  2. Lever *** i have this rn the script is LeverScript.cs***                                                   
  - Player can click to activate                                                                                
  - Should have clear visual feedback (animation preferred)                                                     
  - Fires events when activated                                                                                 
                                                                                                                
  3. Pressure Button                                                                                            
  - Can be pressed by the Dog or movable objects                                                                
  - Should stay pressed while something is on it                                                                
  - Visual feedback when pressed (move down)                                                                    
                                                                                                                
  4. Moving Platform                                                                                            
  - Moves between waypoints                                                                                     
  - Dog and objects should parent to the platform when standing on it                                           
                                                                                                                
  ---                                                                                                           
                                                                                                                
  ## Important Rules & Preferences                                                                              
                                                                                                                
  - Hybrid approach (MonoBehaviour for puzzle objects + prepare for ECSDOTS later)                              
  - Prefer clean, reusable, event-driven design (`UnityEvent` or C# events)                                     
  - Use `Interactable` base class when possible                                                                 
  - Always explain code when modifying or adding new scripts                                                    
  - Focus on beautiful, polished feel (good for emotional game)                                                 
  - Use Animator for doors, levers, and buttons when possible                                                   
                                                                                                                
  ---                                                                                                           
                                                                                                                
  ## Next Tasks  To-Do                                                                                          
                                                                                                                
  - Implement core interaction system for God View (mouse click to interact)                                    
  - Create Door, Lever, PressureButton, MovingPlatform                                                          
  - Connect them together (Lever → Door, Button → Door, etc.)                                                   
  - Dog scent following system (in progress)                                                                    
                                                                                                                
  ---                                                                                                           
                                                                                                                
  Current Date May 2026                                                                                         
  Status Building foundational puzzle mechanics   