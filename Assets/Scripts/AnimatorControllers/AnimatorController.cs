namespace NavyTest.AnimatorControllers
{
    public static class AnimatorController
    {
        public static class Params
        {
            public const string IsRun = nameof(IsRun);
            public const string Death = nameof(Death);
        }

        public static class State
        {
            public const string Idle = nameof(Idle);
            public const string Run = nameof(Run);
        }
    }
}
