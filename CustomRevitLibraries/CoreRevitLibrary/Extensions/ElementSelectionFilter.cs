using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace CoreRevitLibrary.TestCommands
{
    public class ElementSelectionFilter : BaseSelectionFilter
    {
        //private readonly Func<Element, bool> _validateElement;
        private readonly Func<Reference, bool> _validateReference;

        public ElementSelectionFilter(Func<Element, bool> validateElement) : base(validateElement)
        {
        }

        public ElementSelectionFilter(Func<Element, bool> validateElement, Func<Reference, bool> validateReference) : base(validateElement)
        {
            _validateReference = validateReference;
        }

        //public ElementSelectionFilter(Func<Element, bool> validateElement)
        //{
        //    _validateElement = validateElement;
        //}

        //public ElementSelectionFilter(Func<Element, bool> validateElement, Func<Reference, bool> validateReference)
        //:this(validateElement)
        //{
        //    _validateReference = validateReference;
        //}

        public override bool AllowElement(Element elem)
        {
            // _validateElement?.Invoke(elem);  // invokes only in case if elem != null
            return ValidateElement(elem);
        }

        public override bool AllowReference(Reference reference, XYZ position)
        {
            if (_validateReference == null) return true;
            return _validateReference.Invoke(reference);
            //return reference.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_LINEAR;
        }
    }
}