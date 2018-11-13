namespace Lab
{
    class TestReflection
    {
        private int publicProperty;

        public int PublicProperty
        {
            get { return publicProperty; }
        }

        public TestReflection(int publicProperty)
        {
            this.publicProperty = publicProperty;
        }
    }
}
