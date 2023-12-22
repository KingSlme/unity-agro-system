# unity-agro-system
Agro system for Unity 3D.

## Key Features
* Maintains order of GameObjects that enter agro range
* Adjustable agro range with Gizmos

## Setup
1. Add AgroSystem Component to desired GameObject
2. Add ```[Agroable]``` attribute to desired scripts

## Properties

### AgroRange
```cs
public float AgroRange
```

## Methods

### AddTransform
*Adds Transform to agro list.*
```cs
public void AddTransform(Transform transform)
```

### RemoveTransform
*Removes Transform from agro list.*
```cs
public void RemoveTransform(Transform transform)
```

### GetFirstTransform
*Returns first Transform to enter agro list.*
```cs
public Transform GetFirstTransform()
```

### GetMultipleTransforms
*Returns list of x Transforms in the order they entered agro list.*
```cs
 public List<Transform> GetMultipleTransform(int amount)
```

## Dependencies
* None
