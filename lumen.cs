using System;

// Author: Brij Malhotra
// Filename: lumen.cs
// Version: Version 1
// Description: 


// Class invariant: 
namespace lumenClass
{
    public class Lumen
    {

        private readonly int initialBrightness;
        private readonly int initialPower;
        private readonly int size;
        private int brightness;
        private int power;
        private int glowCount;
        private bool active;
        private bool stable;
        private readonly int MIN_POWER;
        private const int RESET_THRESHOLD = 5;
        
        public Lumen(int b = 100, int s = 10, int p = 100)
        {
            initialBrightness = b;
            initialPower = p;
            brightness = b;
            size = s;
            power = p;
            glowCount = 0;
            active = true;
            MIN_POWER = (p / s);
        }
        
        private bool isActive()
        {
            return (power > MIN_POWER);
        }

        private bool isStable()
        {
            return (active && (brightness > (initialBrightness / size)));
        }

        public int glow()
        {
            glowCount++;
            power--;
            active = isActive();
            stable = isStable();

            if (!active)
            {
                return dimnessValue();
            }
            
            if (stable) {
                return magnifiedValue();
            }
            
            return erraticPower();
        }
        
        private int magnifiedValue()
        {
            return (brightness * size);

        }
        private int erraticPower()
        {
            return ((power * brightness) / initialPower);
        }
        
        private int dimnessValue()
        {
            return (brightness / 2);
        }
        
        public void Reset()
        {
            if (glowCount >= RESET_THRESHOLD && (power > 0)){
                brightness = initialBrightness;
                power = initialPower;
                glowCount = 0;
                active = true;
            } else {
                brightness--;
            }
        }
    }
}

// The Lumen class encapsulates the attributes brightness, size, power, resetCount, inactiveThreshold, and resetThreshold.
// The Glow method returns a value determined by the state of the Lumen object, as specified in the problem statement.
// The Reset method allows the client to reset the Lumen object to its original state, but only if the reset count exceeds the reset threshold and the remaining power is positive.
// The DimnessValue method returns a value associated with dimness, as specified in the problem statement.
// The ErraticValue method returns a value associated erratically with the Lumen object's power, as specified in the problem statement.