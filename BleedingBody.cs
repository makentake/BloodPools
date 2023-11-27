using UnityEngine;
using EFT;
using System.Reflection;
using AbsolutDecals;
using Systems.Effects;

namespace BloodPools
{
    public class BleedingBody : MonoBehaviour
    {
        public int toBleed;
        public int bloodRadiusInterval;
        private int currentBloodRadius = 1;

        public float bleedInterval;
        private float currentTime;

        public void MakeBlood(RaycastHit hit)
        {
            var bloodPuddle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            bloodPuddle.transform.position = hit.transform.position;
            bloodPuddle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f)*10;
            bloodPuddle.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.forward);

        }

        public void Bleed(Vector3 pos)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= bleedInterval)
            {
                Plugin.log.LogMessage("at interval");

                //Plugin.log.LogMessage($"toBleed = {toBleed}, result = {toBleed > 0}");

                if (toBleed > 0)
                {
                    Plugin.log.LogMessage("able to bleed");

                    for (int i = 0; i < currentBloodRadius * Plugin.bloodFactor.Value; i++)
                    {
                        var offset = (Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward) * currentBloodRadius;
                        var bloodPos = pos + offset;

                        RaycastHit hit;

                        if (Physics.Raycast(bloodPos, Vector3.down, out hit, Plugin.bloodMaxFallDistance.Value))
                        {
                            Plugin.log.LogMessage("bleeding");

                            //typeof(DecalProjector).GetMethod("DrawBloodOnWall", BindingFlags.NonPublic).Invoke(new object(), new object[] { hit });

                            MakeBlood(hit);
                        }
                    }

                    toBleed--;
                    currentBloodRadius += bloodRadiusInterval;
                }

                currentTime = 0;
            }
        }

        private void Update()
        {
            if (toBleed != 0)
            {
                //Plugin.log.LogMessage($"Update: toBleed = {this.toBleed}, bloodRadiusInterval = {this.bloodRadiusInterval}, bleedInterval = {this.bleedInterval}");

                Bleed(gameObject.GetComponent<Player>().Position);
            }
        }
    }
}
