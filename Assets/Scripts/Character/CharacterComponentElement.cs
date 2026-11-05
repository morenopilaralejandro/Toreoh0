using System.Collections.Generic;
using Aremoreno.Enums.Character;

public class CharacterComponentElement
{
    public List<Element> ListElement;

    public CharacterComponentElement(List<Element> listElement)
    {
        foreach (Element element in listElement) 
        {
            if (element != Element.None)
                ListElement.Add(element);
        }
    }

    public bool Contains(Element element)
    {
        return ListElement.Contains(element);
    }

    public bool ContainsAll(List<Element> listElement)
    {
        foreach (Element element in listElement) 
        {
            if (!Contains(element)) return false;
        }
        return true;
    }

    public bool ContainsAny(List<Element> listElement)
    {
        foreach (Element element in listElement)
        {
            if (Contains(element)) return true;
        }
        return false;
    }

    public bool IsEffective(Element offenseElement, Element defenseElement)
    {
        int offenseIndex = (int) offenseElement;
        int defenseIndex = (int) defenseElement;

        int nextIndex = (offenseIndex + 1) % EnumUtils.GetLength<Element>();
        if (nextIndex == 0) nextIndex++; // None is index 0

        return defenseIndex == nextIndex;
    }
}
