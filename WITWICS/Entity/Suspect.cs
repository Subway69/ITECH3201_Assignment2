using System;

namespace WITWICS.Entity
{
    public class Suspect : NonPlayerCharacter
    {
        // I know exactly what I'm doing now
        private Boolean isTargetVillain;
        private String sex;
        private String hair;
        private String eyes;
        private String hobby;
        private String feature;
        private String vehicle;

        public Suspect(String name, String sex, String hair, String eyes, String hobby, String feature, String vehicle)
        {
            base.name = name;
            this.sex = sex;
            this.hair = hair;
            this.eyes = eyes;
            this.hobby = hobby;
            this.feature = feature;
            this.vehicle = vehicle;
        }

        public Boolean IsTargetVillain
        {
            get { return isTargetVillain; }
            set { isTargetVillain = value; }
        }

        public String Sex
        {
            get { return sex; }
        }

        public String Hair
        {
            get { return hair; }
        }

        public String Eyes
        {
            get { return eyes; }
        }

        public String Hobby
        {
            get { return hobby; }
        }

        public String Feature
        {
            get { return feature; }
        }

        public String Vehicle
        {
            get { return vehicle; }
        }
    }

}
