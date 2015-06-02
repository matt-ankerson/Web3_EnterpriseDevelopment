// Author: Matt Ankerson
// Date: 23 March 2015
// This file contains the model class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1DogSelector.Models
{
    /// <summary>
    /// Yes = 0, No = 1
    /// </summary>
    public enum EYesNo
    {
        Yes = 0,
        No = 1
    }

    /// <summary>
    /// Indicate preference
    /// </summary>
    public enum EScale
    {
        Low = 0,
        Medium = 1,
        High = 2,
        NoPref = 3
    }

    /// <summary>
    /// Indicate Length
    /// </summary>
    public enum ELength
    {
        Short = 0,
        Medium = 1,
        Long = 2
    }

    /// <summary>
    /// Indicate Size
    /// </summary>
    public enum ESize
    {
        Pocket, Tiny, Miniature, Small, Medium, Large, Giant
    }

    /// <summary>
    /// Contains information for a Dog
    /// </summary>
    public class Dog
    {
        public string BreedName         { get; set; }
        public string DisplayName       { get; set; }
        public string ImageName         { get; set; }
        public EScale ActivityLevel     { get; set; }
        public EScale SheddingLevel     { get; set; }
        public EScale GroomingLevel     { get; set; }
        public EScale IntelligenceLevel { get; set; }
        public bool GoodWithChildren    { get; set; }
        public bool Drools              { get; set; }
        public ELength Coatlength       { get; set; }
        public ESize Size               { get; set; }
    }
}