inFluent
===================


inFluent is a simple fluent API for Unity3D GameObjects.
Chain as many methods as you want, including lambda expressions.

----------

Currently supported Unity APIs
--------------
 **GameObject Properties**
 
> - SetName
> - SetTag
> - SetLayer
> - SetStatic
> - ToggleActiveState
> - SetActiveState
> - SetDontDestroyOnLoad
> - GetClone
> - DestroyGameObject

**Transforms**
> - SetTranslation
> - LookAt
> - RotateBy
> - SetLocalPosition
> - SetPosition
> - SetLocalScale

**Components**
>  - AttachComponent
>  - DestroyComponent

Rendering

> - SetMaterial

----------


Basic how to use
-------------

Add the inFluent namespace to our MonoBehaviour class.

    using inFluent;

Now InteliSense will present on any GameObject all avaible extension methods.
Let's consider the following example where we setup a GameObject at OnAwake():

    public Transform StartLookDirection;
    public Vector3 StartScale;
    ...
    OnAwake()
    {
	    this.gameObject.SetDontDestroyOnLoad()
					    .SetLocalScale(StartScale)
					    .LookAt(StartLookDirection.position);
    }

Now we have set three settings with a single statement, much cleaner!
Let's move on to a more interesting example, attaching and setting up a Component with a lambda expression:

    public Transform StartLookDirection
    public AudioClip AmbientMusic;
    public float StartAudioSound;
    ...
    OnAwake()
    {
	    this.gameObject.LookAt(StartLookDirection.position)
					    .AttachComponent<AudioSouce>((r, c) =>
					    {
						    if(r)
						    {
							    c.clip = AmbientMusic;
							    c.loop = true;
							    c.volumen = StartAudioSound;
							    c.Play();
						    }
					    });
    }

As you can see, we have attached and setup a Component while also calling another method from inside the lambdas scope!
