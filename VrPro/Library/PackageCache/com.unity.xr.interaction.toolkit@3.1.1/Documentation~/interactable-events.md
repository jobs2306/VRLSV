---
uid: xri-interactable-events
---
# Interactable Events

These are events that can be hooked into in the editor the same way you would respond to a UI button press. These apply to Interactables - objects that Interactors can interact with.

| **Property** | **Description** |
|---|---|
| **First Hover Entered** | The event that is called only when the first Interactor begins hovering over this Interactable as the sole hovering Interactor. Subsequent Interactors that begin hovering over this Interactable will not cause this event to be invoked as long as any others are still hovering.<br />The `HoverEnterEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Last Hover Exited** | The event that is called only when the last remaining hovering Interactor ends hovering over this Interactable.<br />The `HoverExitEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Hover Entered** | The event that is called when an Interactor begins hovering over this Interactable.<br />The `HoverEnterEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Hover Exited** | The event that is called when an Interactor ends hovering over this Interactable.<br />The `HoverExitEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **First Select Entered** | The event that is called only when the first Interactor begins selecting this Interactable as the sole selecting Interactor. Subsequent Interactors that begin selecting this Interactable will not cause this event to be invoked as long as any others are still selecting.<br />The `SelectEnterEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Last Select Exited** | The event that is called only when the last remaining selecting Interactor ends selecting this Interactable.<br />The `SelectExitEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Select Entered** | The event that is called when an Interactor begins selecting this Interactable.<br />The `SelectEnterEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Select Exited** | The event that is called when an Interactor ends selecting this Interactable.<br />The `SelectExitEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Activated** | The event that is called when the selecting Interactor activates this Interactable.<br />Not to be confused with activating or deactivating a `GameObject` with `GameObject.SetActive`. This is a generic event when an Interactor wants to activate an Interactable, such as from a trigger pull on a controller.<br />The `ActivateEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
| **Deactivated** | The event that is called when an Interactor deactivates this Interactable.<br />Not to be confused with activating or deactivating a `GameObject` with `GameObject.SetActive`. This is a generic event when an Interactor wants to deactivate an Interactable, such as from a trigger release on a controller.<br />The `DeactivateEventArgs` passed to each listener is only valid while the event is invoked, do not hold a reference to it. |
