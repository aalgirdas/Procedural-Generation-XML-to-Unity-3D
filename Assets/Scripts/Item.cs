using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Item {

    [XmlAttribute("name")]
    public string name="";

    [XmlAttribute("item_type")]
    public string item_type = "";

    [XmlElement("TimeToShow")]
    public float fTimeToShow = -1;  // -1 This indicates that there is no need to check for the element instantiation event. 

    [XmlElement("TimeToStop")]
    public float fTimeToStop = -1;  // -1 This indicates that there is no need to check for the element stop event. 

    [XmlElement("CanvasText")]
    public string sCanvasText = null;

    [XmlElement("Verb")]
    public string sVerb = null;

    [XmlElement("VerbType")]        // In the current version, it can have the following values: { Motion ; InMotion ; NoMotion } 
    public string sVerbType = null;

    [XmlElement("FrameInfo")]        // FrameNet info
    public string sFrameInfo = null;

    //  [XmlElement("VerbTime")]
    //   public float fVerbTime = -1;  // -1 This indicates that there is no need to check for the verb trigger event. 

    [XmlElement("Type")]
    public string sType="";

    [XmlElement("PozX")]
    public float fPozX = 0;
    [XmlElement("PozY")]
    public float fPozY = 0;
    [XmlElement("PozZ")]
    public float fPozZ = 0;


    [XmlElement("TargetX")]
    public float fTargetX ;
    [XmlElement("TargetY")]
    public float fTargetY;
    [XmlElement("TargetZ")]
    public float fTargetZ;



    [XmlElement("RotX")]
    public float fRotX = 0;
    [XmlElement("RotY")]
    public float fRotY = 0;
    [XmlElement("RotZ")]
    public float fRotZ = 0;


    [XmlElement("ScaleX")]
    public float fScaleX=1;
    [XmlElement("ScaleY")]
    public float fScaleY=1;
    [XmlElement("ScaleZ")]
    public float fScaleZ=1;

    [XmlElement("VelocityX")]
    public float fVelocityX = 0;
    [XmlElement("VelocityY")]
    public float fVelocityY = 0;
    [XmlElement("VelocityZ")]
    public float fVelocityZ = 0;

    [XmlElement("Speed")]
    public float fSpeed = 0;


    [XmlElement("ForceX")]
    public float fForceX = 0;
    [XmlElement("ForceY")]
    public float fForceY = 0;
    [XmlElement("ForceZ")]
    public float fForceZ = 0;

    [XmlElement("Mass")]
    public float fMass = 1;


}
