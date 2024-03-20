using System.ComponentModel;

namespace MyFirstAPI.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        Todo = 1,
        [Description("Sendo Realizada")]
        Doing = 2,
        [Description("Concluido")]
        Concluded = 3,
    }
}
