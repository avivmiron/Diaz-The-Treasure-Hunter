/***************************************************************
* file: ObjectCollision.js
* author: Ofir Miron, Aviv Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This script detects object collisions with the player and applies damage.
*
****************************************************************/ 

// Transform component
var target: Transform;

// Damage
private var damage = 100;

// Apply damage to target upon collision 
function OnTriggerEnter(col: Collider){
    if(col.gameObject == target.gameObject) {
        target.SendMessage("ApplyDamage", damage);
    }
}