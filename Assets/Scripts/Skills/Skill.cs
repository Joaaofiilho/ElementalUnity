using Characters;

namespace Skills
{
    public abstract class Skill
    {
        public SkillTypes Type;
        protected Character Character;
        protected bool Performing;

        public Skill(Character character, SkillTypes type)
        {
            Character = character;
            Type = type;
        }
        
        public abstract void TryToPerform();

        public virtual void Update(Character character, float deltaTime)
        {
            
        }
    }
}