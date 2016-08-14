inFluent
===================


inFluent is a simple fluent API for Unity3D GameObjects.
This means that you can chain inline as many methods are you want - including lambdas!

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

Before we get the extension methods, we need to add the inFluent namespace to out class.

    using inFluent;

Now we can simply reference any GameObject and InteliSense to show us all available extension methods.
Let's consider the following example where we have a Script on our GameObject and we make some settings at OnAwake().

    public Transform StartLookDirection;
    public Vector3 StartScale;
    ...
    OnAwake()
    {
	    this.gameObject.SetDontDestroyOnLoad()
					    .SetLocalScale(StartScale)
					    .LookAt(StartLookDirection.position);
    }

Now we have set three settings with a single statement, isn't this much cleaner?
Let's move to a more interesting example, attaching a Component with a lambda!

    public Transform StartLookDurction
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

As you can see, we have made again not just several settings inline, but also managed effortless changes to the attached component and even invoked a method!

Future
------
inFluent is just a small side project but feel free to request or contribute more extensions for Unity API's.
At this stage, there are not stepstones are other concrete plans.
