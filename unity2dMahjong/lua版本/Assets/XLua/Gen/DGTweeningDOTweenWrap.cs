#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class DGTweeningDOTweenWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.DOTween);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 45, 16, 16);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Init", _m_Init_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTweensCapacity", _m_SetTweensCapacity_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clear", _m_Clear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClearCachedTweens", _m_ClearCachedTweens_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Validate", _m_Validate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ManualUpdate", _m_ManualUpdate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "To", _m_To_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToAxis", _m_ToAxis_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToAlpha", _m_ToAlpha_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Punch", _m_Punch_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Shake", _m_Shake_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToArray", _m_ToArray_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sequence", _m_Sequence_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CompleteAll", _m_CompleteAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Complete", _m_Complete_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FlipAll", _m_FlipAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Flip", _m_Flip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GotoAll", _m_GotoAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Goto", _m_Goto_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "KillAll", _m_KillAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Kill", _m_Kill_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PauseAll", _m_PauseAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Pause", _m_Pause_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayAll", _m_PlayAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Play", _m_Play_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayBackwardsAll", _m_PlayBackwardsAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayBackwards", _m_PlayBackwards_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayForwardAll", _m_PlayForwardAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayForward", _m_PlayForward_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RestartAll", _m_RestartAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Restart", _m_Restart_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RewindAll", _m_RewindAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Rewind", _m_Rewind_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SmoothRewindAll", _m_SmoothRewindAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SmoothRewind", _m_SmoothRewind_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TogglePauseAll", _m_TogglePauseAll_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TogglePause", _m_TogglePause_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsTweening", _m_IsTweening_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TotalPlayingTweens", _m_TotalPlayingTweens_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayingTweens", _m_PlayingTweens_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PausedTweens", _m_PausedTweens_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TweensById", _m_TweensById_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TweensByTarget", _m_TweensByTarget_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Version", DG.Tweening.DOTween.Version);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "logBehaviour", _g_get_logBehaviour);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "useSafeMode", _g_get_useSafeMode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "showUnityEditorReport", _g_get_showUnityEditorReport);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "timeScale", _g_get_timeScale);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "useSmoothDeltaTime", _g_get_useSmoothDeltaTime);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "maxSmoothUnscaledTime", _g_get_maxSmoothUnscaledTime);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "drawGizmos", _g_get_drawGizmos);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultUpdateType", _g_get_defaultUpdateType);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultTimeScaleIndependent", _g_get_defaultTimeScaleIndependent);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultAutoPlay", _g_get_defaultAutoPlay);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultAutoKill", _g_get_defaultAutoKill);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultLoopType", _g_get_defaultLoopType);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultRecyclable", _g_get_defaultRecyclable);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultEaseType", _g_get_defaultEaseType);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultEaseOvershootOrAmplitude", _g_get_defaultEaseOvershootOrAmplitude);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultEasePeriod", _g_get_defaultEasePeriod);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "logBehaviour", _s_set_logBehaviour);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "useSafeMode", _s_set_useSafeMode);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "showUnityEditorReport", _s_set_showUnityEditorReport);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "timeScale", _s_set_timeScale);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "useSmoothDeltaTime", _s_set_useSmoothDeltaTime);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "maxSmoothUnscaledTime", _s_set_maxSmoothUnscaledTime);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "drawGizmos", _s_set_drawGizmos);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultUpdateType", _s_set_defaultUpdateType);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultTimeScaleIndependent", _s_set_defaultTimeScaleIndependent);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultAutoPlay", _s_set_defaultAutoPlay);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultAutoKill", _s_set_defaultAutoKill);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultLoopType", _s_set_defaultLoopType);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultRecyclable", _s_set_defaultRecyclable);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultEaseType", _s_set_defaultEaseType);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultEaseOvershootOrAmplitude", _s_set_defaultEaseOvershootOrAmplitude);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "defaultEasePeriod", _s_set_defaultEasePeriod);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DG.Tweening.DOTween __cl_gen_ret = new DG.Tweening.DOTween();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<System.Nullable<bool>>(L, 1)&& translator.Assignable<System.Nullable<bool>>(L, 2)&& translator.Assignable<System.Nullable<DG.Tweening.LogBehaviour>>(L, 3)) 
                {
                    System.Nullable<bool> recycleAllByDefault;translator.Get(L, 1, out recycleAllByDefault);
                    System.Nullable<bool> useSafeMode;translator.Get(L, 2, out useSafeMode);
                    System.Nullable<DG.Tweening.LogBehaviour> logBehaviour;translator.Get(L, 3, out logBehaviour);
                    
                        DG.Tweening.IDOTweenInit __cl_gen_ret = DG.Tweening.DOTween.Init( recycleAllByDefault, useSafeMode, logBehaviour );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Nullable<bool>>(L, 1)&& translator.Assignable<System.Nullable<bool>>(L, 2)) 
                {
                    System.Nullable<bool> recycleAllByDefault;translator.Get(L, 1, out recycleAllByDefault);
                    System.Nullable<bool> useSafeMode;translator.Get(L, 2, out useSafeMode);
                    
                        DG.Tweening.IDOTweenInit __cl_gen_ret = DG.Tweening.DOTween.Init( recycleAllByDefault, useSafeMode );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<System.Nullable<bool>>(L, 1)) 
                {
                    System.Nullable<bool> recycleAllByDefault;translator.Get(L, 1, out recycleAllByDefault);
                    
                        DG.Tweening.IDOTweenInit __cl_gen_ret = DG.Tweening.DOTween.Init( recycleAllByDefault );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        DG.Tweening.IDOTweenInit __cl_gen_ret = DG.Tweening.DOTween.Init(  );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Init!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTweensCapacity_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int tweenersCapacity = LuaAPI.xlua_tointeger(L, 1);
                    int sequencesCapacity = LuaAPI.xlua_tointeger(L, 2);
                    
                    DG.Tweening.DOTween.SetTweensCapacity( tweenersCapacity, sequencesCapacity );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool destroy = LuaAPI.lua_toboolean(L, 1);
                    
                    DG.Tweening.DOTween.Clear( destroy );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 0) 
                {
                    
                    DG.Tweening.DOTween.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Clear!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCachedTweens_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    DG.Tweening.DOTween.ClearCachedTweens(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Validate_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Validate(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ManualUpdate_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float deltaTime = (float)LuaAPI.lua_tonumber(L, 1);
                    float unscaledDeltaTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    DG.Tweening.DOTween.ManualUpdate( deltaTime, unscaledDeltaTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_To_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOSetter<float>>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOSetter<float> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<float>>(L, 1);
                    float startValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( setter, startValue, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<float>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<float>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<float> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<float>>(L, 1);
                    DG.Tweening.Core.DOSetter<float> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<float>>(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<double>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<double>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<double> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<double>>(L, 1);
                    DG.Tweening.Core.DOSetter<double> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<double>>(L, 2);
                    double endValue = LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<double, double, DG.Tweening.Plugins.Options.NoOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<int>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<int>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<int> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<int>>(L, 1);
                    DG.Tweening.Core.DOSetter<int> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<int>>(L, 2);
                    int endValue = LuaAPI.xlua_tointeger(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<uint>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<uint>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<uint> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<uint>>(L, 1);
                    DG.Tweening.Core.DOSetter<uint> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<uint>>(L, 2);
                    uint endValue = LuaAPI.xlua_touint(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<long>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<long>>(L, 2)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<long> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<long>>(L, 1);
                    DG.Tweening.Core.DOSetter<long> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<long>>(L, 2);
                    long endValue = LuaAPI.lua_toint64(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<ulong>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<ulong>>(L, 2)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isuint64(L, 3))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<ulong> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<ulong>>(L, 1);
                    DG.Tweening.Core.DOSetter<ulong> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<ulong>>(L, 2);
                    ulong endValue = LuaAPI.lua_touint64(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<string>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<string>>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<string> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<string>>(L, 1);
                    DG.Tweening.Core.DOSetter<string> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<string>>(L, 2);
                    string endValue = LuaAPI.lua_tostring(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<string, string, DG.Tweening.Plugins.Options.StringOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector2>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector2>>(L, 2)&& translator.Assignable<UnityEngine.Vector2>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector2> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector2>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector2> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector2>>(L, 2);
                    UnityEngine.Vector2 endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    UnityEngine.Vector3 endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector4>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector4>>(L, 2)&& translator.Assignable<UnityEngine.Vector4>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector4> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector4>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector4> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector4>>(L, 2);
                    UnityEngine.Vector4 endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Quaternion>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Quaternion>>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Quaternion> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Quaternion>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Quaternion> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Quaternion>>(L, 2);
                    UnityEngine.Vector3 endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Color>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Color>>(L, 2)&& translator.Assignable<UnityEngine.Color>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Color> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Color>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Color> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Color>>(L, 2);
                    UnityEngine.Color endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Rect>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Rect>>(L, 2)&& translator.Assignable<UnityEngine.Rect>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Rect> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Rect>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Rect> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Rect>>(L, 2);
                    UnityEngine.Rect endValue;translator.Get(L, 3, out endValue);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions> __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.RectOffset>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.RectOffset>>(L, 2)&& translator.Assignable<UnityEngine.RectOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.RectOffset> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.RectOffset>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.RectOffset> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.RectOffset>>(L, 2);
                    UnityEngine.RectOffset endValue = (UnityEngine.RectOffset)translator.GetObject(L, 3, typeof(UnityEngine.RectOffset));
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.To( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.To!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToAxis_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<DG.Tweening.AxisConstraint>(L, 5)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    DG.Tweening.AxisConstraint axisConstraint;translator.Get(L, 5, out axisConstraint);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> __cl_gen_ret = DG.Tweening.DOTween.ToAxis( getter, setter, endValue, duration, axisConstraint );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> __cl_gen_ret = DG.Tweening.DOTween.ToAxis( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.ToAxis!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToAlpha_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Color> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Color>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Color> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Color>>(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOTween.ToAlpha( getter, setter, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Punch_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 6&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    UnityEngine.Vector3 direction;translator.Get(L, 3, out direction);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float elasticity = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Punch( getter, setter, direction, duration, vibrato, elasticity );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    UnityEngine.Vector3 direction;translator.Get(L, 3, out direction);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Punch( getter, setter, direction, duration, vibrato );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    UnityEngine.Vector3 direction;translator.Get(L, 3, out direction);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Punch( getter, setter, direction, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Punch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Shake_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 8&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float randomness = (float)LuaAPI.lua_tonumber(L, 6);
                    bool ignoreZAxis = LuaAPI.lua_toboolean(L, 7);
                    bool fadeOut = LuaAPI.lua_toboolean(L, 8);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato, randomness, ignoreZAxis, fadeOut );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float randomness = (float)LuaAPI.lua_tonumber(L, 6);
                    bool ignoreZAxis = LuaAPI.lua_toboolean(L, 7);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato, randomness, ignoreZAxis );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float randomness = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato, randomness );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float strength = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector3 strength;translator.Get(L, 4, out strength);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float randomness = (float)LuaAPI.lua_tonumber(L, 6);
                    bool fadeOut = LuaAPI.lua_toboolean(L, 7);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato, randomness, fadeOut );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector3 strength;translator.Get(L, 4, out strength);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    float randomness = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato, randomness );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector3 strength;translator.Get(L, 4, out strength);
                    int vibrato = LuaAPI.xlua_tointeger(L, 5);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength, vibrato );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1)&& translator.Assignable<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector3 strength;translator.Get(L, 4, out strength);
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.Shake( getter, setter, duration, strength );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Shake!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    DG.Tweening.Core.DOGetter<UnityEngine.Vector3> getter = translator.GetDelegate<DG.Tweening.Core.DOGetter<UnityEngine.Vector3>>(L, 1);
                    DG.Tweening.Core.DOSetter<UnityEngine.Vector3> setter = translator.GetDelegate<DG.Tweening.Core.DOSetter<UnityEngine.Vector3>>(L, 2);
                    UnityEngine.Vector3[] endValues = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    float[] durations = (float[])translator.GetObject(L, 4, typeof(float[]));
                    
                        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> __cl_gen_ret = DG.Tweening.DOTween.ToArray( getter, setter, endValues, durations );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sequence_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        DG.Tweening.Sequence __cl_gen_ret = DG.Tweening.DOTween.Sequence(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompleteAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool withCallbacks = LuaAPI.lua_toboolean(L, 1);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.CompleteAll( withCallbacks );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.CompleteAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.CompleteAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Complete_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool withCallbacks = LuaAPI.lua_toboolean(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Complete( targetOrId, withCallbacks );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Complete( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Complete!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FlipAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.FlipAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Flip_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Flip( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    float to = (float)LuaAPI.lua_tonumber(L, 1);
                    bool andPlay = LuaAPI.lua_toboolean(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.GotoAll( to, andPlay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float to = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.GotoAll( to );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.GotoAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Goto_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    bool andPlay = LuaAPI.lua_toboolean(L, 3);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Goto( targetOrId, to, andPlay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Goto( targetOrId, to );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Goto!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_KillAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool complete = LuaAPI.lua_toboolean(L, 1);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.KillAll( complete );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.KillAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count >= 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    bool complete = LuaAPI.lua_toboolean(L, 1);
                    object[] idsOrTargetsToExclude = translator.GetParams<object>(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.KillAll( complete, idsOrTargetsToExclude );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.KillAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Kill_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool complete = LuaAPI.lua_toboolean(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Kill( targetOrId, complete );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Kill( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Kill!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PauseAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Pause( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Play( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Play( target, id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Play!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayBackwardsAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayBackwardsAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayBackwards_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayBackwards( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayBackwards( target, id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PlayBackwards!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayForwardAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayForwardAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayForward_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayForward( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.PlayForward( target, id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PlayForward!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RestartAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool includeDelay = LuaAPI.lua_toboolean(L, 1);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.RestartAll( includeDelay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.RestartAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.RestartAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Restart_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool includeDelay = LuaAPI.lua_toboolean(L, 2);
                    float changeDelayTo = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( targetOrId, includeDelay, changeDelayTo );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool includeDelay = LuaAPI.lua_toboolean(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( targetOrId, includeDelay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    bool includeDelay = LuaAPI.lua_toboolean(L, 3);
                    float changeDelayTo = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( target, id, includeDelay, changeDelayTo );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    bool includeDelay = LuaAPI.lua_toboolean(L, 3);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( target, id, includeDelay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    object id = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Restart( target, id );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Restart!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RewindAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool includeDelay = LuaAPI.lua_toboolean(L, 1);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.RewindAll( includeDelay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.RewindAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.RewindAll!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rewind_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool includeDelay = LuaAPI.lua_toboolean(L, 2);
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Rewind( targetOrId, includeDelay );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.Rewind( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Rewind!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothRewindAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.SmoothRewindAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothRewind_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.SmoothRewind( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TogglePauseAll_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.TogglePauseAll(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TogglePause_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.TogglePause( targetOrId );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTweening_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    bool alsoCheckIfIsPlaying = LuaAPI.lua_toboolean(L, 2);
                    
                        bool __cl_gen_ret = DG.Tweening.DOTween.IsTweening( targetOrId, alsoCheckIfIsPlaying );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object targetOrId = translator.GetObject(L, 1, typeof(object));
                    
                        bool __cl_gen_ret = DG.Tweening.DOTween.IsTweening( targetOrId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.IsTweening!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TotalPlayingTweens_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = DG.Tweening.DOTween.TotalPlayingTweens(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayingTweens_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.PlayingTweens(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PausedTweens_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.PausedTweens(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TweensById_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object id = translator.GetObject(L, 1, typeof(object));
                    bool playingOnly = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.TweensById( id, playingOnly );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object id = translator.GetObject(L, 1, typeof(object));
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.TweensById( id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.TweensById!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TweensByTarget_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    bool playingOnly = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.TweensByTarget( target, playingOnly );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    
                        System.Collections.Generic.List<DG.Tweening.Tween> __cl_gen_ret = DG.Tweening.DOTween.TweensByTarget( target );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.TweensByTarget!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_logBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushDGTweeningLogBehaviour(L, DG.Tweening.DOTween.logBehaviour);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useSafeMode(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.useSafeMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showUnityEditorReport(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.showUnityEditorReport);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_timeScale(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, DG.Tweening.DOTween.timeScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useSmoothDeltaTime(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.useSmoothDeltaTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxSmoothUnscaledTime(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, DG.Tweening.DOTween.maxSmoothUnscaledTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drawGizmos(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.drawGizmos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultUpdateType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushDGTweeningUpdateType(L, DG.Tweening.DOTween.defaultUpdateType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultTimeScaleIndependent(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.defaultTimeScaleIndependent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultAutoPlay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushDGTweeningAutoPlay(L, DG.Tweening.DOTween.defaultAutoPlay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultAutoKill(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.defaultAutoKill);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultLoopType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushDGTweeningLoopType(L, DG.Tweening.DOTween.defaultLoopType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultRecyclable(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, DG.Tweening.DOTween.defaultRecyclable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultEaseType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushDGTweeningEase(L, DG.Tweening.DOTween.defaultEaseType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultEaseOvershootOrAmplitude(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultEasePeriod(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, DG.Tweening.DOTween.defaultEasePeriod);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_logBehaviour(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			DG.Tweening.LogBehaviour __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				DG.Tweening.DOTween.logBehaviour = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useSafeMode(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.useSafeMode = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showUnityEditorReport(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.showUnityEditorReport = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_timeScale(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.timeScale = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useSmoothDeltaTime(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.useSmoothDeltaTime = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxSmoothUnscaledTime(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.maxSmoothUnscaledTime = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_drawGizmos(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.drawGizmos = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultUpdateType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			DG.Tweening.UpdateType __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				DG.Tweening.DOTween.defaultUpdateType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultTimeScaleIndependent(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.defaultTimeScaleIndependent = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultAutoPlay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			DG.Tweening.AutoPlay __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				DG.Tweening.DOTween.defaultAutoPlay = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultAutoKill(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.defaultAutoKill = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultLoopType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			DG.Tweening.LoopType __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				DG.Tweening.DOTween.defaultLoopType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultRecyclable(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.defaultRecyclable = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultEaseType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			DG.Tweening.Ease __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				DG.Tweening.DOTween.defaultEaseType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultEaseOvershootOrAmplitude(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultEasePeriod(RealStatePtr L)
        {
		    try {
                
			    DG.Tweening.DOTween.defaultEasePeriod = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
