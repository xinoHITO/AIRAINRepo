using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CreateFireball : RAINAction
{
	private EthanAI _ethanScript;
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_ethanScript = ai.Body.GetComponent<EthanAI>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		_ethanScript.CreateFireball();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}