
namespace TowerDefenseSpel.GamePlay
{
    public interface IKillable
    {
        void OnDeath();

        float Hp { get; set; }
    }
}
