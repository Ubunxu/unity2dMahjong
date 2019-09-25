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
    public class DGTweeningDOVirtualWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DG.Tweening.DOVirtual);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Float", _m_Float_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EasedValue", _m_EasedValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DelayedCall", _m_DelayedCall_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "DG.Tweening.DOVirtual does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Float_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float from = (float)LuaAPI.lua_tonumber(L, 1);
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    float duration = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.TweenCallback<float> onVirtualUpdate = translator.GetDelegate<DG.Tweening.TweenCallback<float>>(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = DG.Tweening.DOVirtual.Float( from, to, duration, onVirtualUpdate );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EasedValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)) 
                {
                    float from = (float)LuaAPI.lua_tonumber(L, 1);
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    float lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease easeType;translator.Get(L, 4, out easeType);
                    
                        float __cl_gen_ret = DG.Tweening.DOVirtual.EasedValue( from, to, lifetimePercentage, easeType );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.AnimationCurve>(L, 4)) 
                {
                    float from = (float)LuaAPI.lua_tonumber(L, 1);
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    float lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.AnimationCurve easeCurve = (UnityEngine.AnimationCurve)translator.GetObject(L, 4, typeof(UnityEngine.AnimationCurve));
                    
                        float __cl_gen_ret = DG.Tweening.DOVirtual.EasedValue( from, to, lifetimePercentage, easeCurve );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float from = (float)LuaAPI.lua_tonumber(L, 1);
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    float lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease easeType;translator.Get(L, 4, out easeType);
                    float overshoot = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        float __cl_gen_ret = DG.Tweening.DOVirtual.EasedValue( from, to, lifetimePercentage, easeType, overshoot );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<DG.Tweening.Ease>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    float from = (float)LuaAPI.lua_tonumber(L, 1);
                    float to = (float)LuaAPI.lua_tonumber(L, 2);
                    float lifetimePercentage = (float)LuaAPI.lua_tonumber(L, 3);
                    DG.Tweening.Ease easeType;translator.Get(L, 4, out easeType);
                    float amplitude = (float)LuaAPI.lua_tonumber(L, 5);
                    float period = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        float __cl_gen_ret = DG.Tweening.DOVirtual.EasedValue( from, to, lifetimePercentage, easeType, amplitude, period );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.EasedValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelayedCall_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float delay = (float)LuaAPI.lua_tonumber(L, 1);
                    DG.Tweening.TweenCallback callback = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    bool ignoreTimeScale = LuaAPI.lua_toboolean(L, 3);
                    
                        DG.Tweening.Tween __cl_gen_ret = DG.Tweening.DOVirtual.DelayedCall( delay, callback, ignoreTimeScale );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 2)) 
                {
                    float delay = (float)LuaAPI.lua_tonumber(L, 1);
                    DG.Tweening.TweenCallback callback = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 2);
                    
                        DG.Tweening.Tween __cl_gen_ret = DG.Tweening.DOVirtual.DelayedCall( delay, callback );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DG.Tweening.DOVirtual.DelayedCall!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
