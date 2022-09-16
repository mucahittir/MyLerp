using System.Collections;
using System;
using UnityEngine;

public static class LerpTransform
{
    public static IEnumerator LerpTransformToPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = lerpTransformToPos(transform,targetPosition,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator LerpTransformToPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction)
    {
        IEnumerator func = lerpTransformToPos(transform,targetPosition,duration,easeFunction,null);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator LerpTransformToPosition(Transform transform,Vector3 targetPosition,float duration, Action onFinish)
    {
        IEnumerator func = lerpTransformToPos(transform,targetPosition,duration,EaseFunctions.InOutSine,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator LerpTransformToPosition(Transform transform,Vector3 targetPosition,float duration)
    {
        IEnumerator func = lerpTransformToPos(transform,targetPosition,duration,EaseFunctions.InOutSine,null);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator LerpTransformToPositionWithRotation(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = lerpTransformToPosWithRot(transform,targetPosition,targetRotation,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }

    public static IEnumerator LerpTransformToLocalPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = lerpTransformToLocalPos(transform,targetPosition,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator SlerpTransformToLocalPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = slerpTransformToLocalPos(transform,targetPosition,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator LerpTransformToLocalPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction)
    {
        IEnumerator func = lerpTransformToLocalPos(transform,targetPosition,duration,easeFunction,null);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator SlerpTransformToLocalPositionWithRotation(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = slerpTransformToLocalPosWithRotation(transform,targetPosition,targetRotation,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator SlerpTransformToPosition(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = slerpTransformToPos(transform,targetPosition,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }
    public static IEnumerator SlerpTransformToPositionWithRotation(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        IEnumerator func = slerpTransformToPosWithRot(transform,targetPosition,targetRotation,duration,easeFunction,onFinish);
        CoroutineHelper.Start(func);
        return func;
    }

    public static void StopLerp(IEnumerator co)
    {
        CoroutineHelper.Stop(co);
    }

    private static IEnumerator lerpTransformToPos(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time;
        time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        if(onFinish != null)
        {
            onFinish();
        }
    }
    private static IEnumerator lerpTransformToPosWithRot(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time;
        time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            transform.rotation = Quaternion.Lerp(transform.localRotation,targetRotation,t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        if(onFinish != null)
        {
            onFinish();
        }
    }

    private static IEnumerator lerpTransformToLocalPos(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time = 0;
        Vector3 startPosition = transform.localPosition;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
        if(onFinish != null)
        {
            onFinish();
        }
    }

    private static IEnumerator slerpTransformToLocalPos(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time = 0;
        Vector3 startPosition = transform.localPosition;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.localPosition = Vector3.Slerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
        if(onFinish != null)
        {
            onFinish();
        }
    }
    private static IEnumerator slerpTransformToPos(Transform transform,Vector3 targetPosition,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.position = Vector3.Slerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        if(onFinish != null)
        {
            onFinish();
        }
    }

    private static IEnumerator slerpTransformToLocalPosWithRotation(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time = 0;
        Vector3 startPosition = transform.localPosition;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.localPosition = Vector3.Slerp(startPosition, targetPosition, t);
            transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation,t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
        transform.localRotation = targetRotation;
        if(onFinish != null)
        {
            onFinish();
        }
    }
    private static IEnumerator slerpTransformToPosWithRot(Transform transform,Vector3 targetPosition,Quaternion targetRotation,float duration,Func<float,float> easeFunction, Action onFinish)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            float t = time / duration;
            t = easeFunction(t);
            transform.position = Vector3.Slerp(startPosition, targetPosition, t);
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.rotation = targetRotation;
        if(onFinish != null)
        {
            onFinish();
        }
    }
}
