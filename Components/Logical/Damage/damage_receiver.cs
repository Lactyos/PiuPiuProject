using System;
using Godot;

public class DamageReceiver
{
    public Health health;
    public Area2D hitbox;
    public float damage_cooldown;
    public float timePassed = 0;
    public DamageReceiver(ref Health health, ref Area2D hitbox, float damage_cooldown) {
        this.health = health;
        this.hitbox = hitbox;
        this.damage_cooldown = damage_cooldown;
    }
    public void ApplyCollidingDamage(float delta) {
        var bodies = hitbox.GetOverlappingAreas();
        if (timePassed >= damage_cooldown) {
            foreach (var body in bodies) {
                DamageSource body_dealer = body as DamageSource;
                if (body != null) {
                    health.TakeDamage(body_dealer.damage);
                }
            }
            timePassed =0;
        }
        timePassed += delta;
    }
}