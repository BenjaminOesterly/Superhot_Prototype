# Superhot_Prototype

This project prototypes the core time movement mechanic from Superhot. Time slows down to a crawl when the player stands still. When the player walks or looks around time speeds back up to normal.

I used an interface called IHittable to handle bullet collisions without type casting. I applied Time deltaTime to keep the physics and camera movement smooth when the time scale changes. For initialization I put internal setup code in Awake and placed external references like finding the player in Start.

Despite my initial idea, I decided not to add much to the player damage mechanic to keep the project small. Instead I just used a debug log that prints to the console when the player gets hit. This let me focus entirely on making the time movement feel right.

