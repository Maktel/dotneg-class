﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1590.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class root {
    
    private string effortField;
    
    private rootBreathe[] breatheField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string effort {
        get {
            return this.effortField;
        }
        set {
            this.effortField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("breathe", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootBreathe[] breathe {
        get {
            return this.breatheField;
        }
        set {
            this.breatheField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreathe {
    
    private rootBreatheDO[] doField;
    
    private rootBreatheJungle[] jungleField;
    
    private string machineField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("do", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootBreatheDO[] @do {
        get {
            return this.doField;
        }
        set {
            this.doField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("jungle", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
    public rootBreatheJungle[] jungle {
        get {
            return this.jungleField;
        }
        set {
            this.jungleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string machine {
        get {
            return this.machineField;
        }
        set {
            this.machineField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreatheDO {
    
    private rootBreatheDODate0[] date0Field;
    
    private rootBreatheDODate1[] date1Field;
    
    private rootBreatheDODate2[] date2Field;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date0", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootBreatheDODate0[] date0 {
        get {
            return this.date0Field;
        }
        set {
            this.date0Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date1", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootBreatheDODate1[] date1 {
        get {
            return this.date1Field;
        }
        set {
            this.date1Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date2", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootBreatheDODate2[] date2 {
        get {
            return this.date2Field;
        }
        set {
            this.date2Field = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreatheDODate0 {
    
    private string hourField;
    
    private string minuteField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hour {
        get {
            return this.hourField;
        }
        set {
            this.hourField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string minute {
        get {
            return this.minuteField;
        }
        set {
            this.minuteField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreatheDODate1 {
    
    private string hourField;
    
    private string minuteField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hour {
        get {
            return this.hourField;
        }
        set {
            this.hourField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string minute {
        get {
            return this.minuteField;
        }
        set {
            this.minuteField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreatheDODate2 {
    
    private string hourField;
    
    private string minuteField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hour {
        get {
            return this.hourField;
        }
        set {
            this.hourField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string minute {
        get {
            return this.minuteField;
        }
        set {
            this.minuteField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootBreatheJungle {
    
    private string outerField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string outer {
        get {
            return this.outerField;
        }
        set {
            this.outerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1590.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class NewDataSet {
    
    private root[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("root")]
    public root[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}
