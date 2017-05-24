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