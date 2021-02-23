using Characters;

namespace Skills
{
    public class DashSkill: Skill
    {
        private CharacterWalkable _characterWalkable;
        private float duration;

        public DashSkill(CharacterWalkable characterWalkable) : base(characterWalkable, SkillTypes.Dash)
        {
            _characterWalkable = Character as CharacterWalkable;
        }

        public override void TryToPerform()
        {
            if (!Performing)
            {
                Performing = true;
                _characterWalkable.SetCanMove(false);
            }
        }
    }
}