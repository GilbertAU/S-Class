using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAgroed { get; set; }
    bool IsWithinStrikingDistance { get; set; }
    void SetAgroStatus(bool isAgroed);
    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
