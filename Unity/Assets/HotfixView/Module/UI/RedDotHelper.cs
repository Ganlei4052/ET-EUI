﻿using UnityEngine;

namespace ET
{
    public static class RedDotHelper
    {
        /// <summary>
        /// 增加逻辑红点节点
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="parent"></param>
        /// <param name="target"></param>
        /// <param name="isNeedShowNum"></param>
        public static void AddRodDotNode(Scene ZoneScene, string parent, string target,bool isNeedShowNum)
        {
            RedDotComponent RedDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (RedDotComponent == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(parent) && !RedDotComponent.RedDotNodeParentsDict.ContainsKey(parent))
            {
                Log.Warning("Runtime动态添加的红点，其父节点是新节点： " + parent);
            }

            RedDotComponent.AddRodDotNode(parent, target, isNeedShowNum);
        }
        
        /// <summary>
        /// 移除逻辑红点
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="target"></param>
        /// <param name="isRemoveView"></param>
        public static void RemoveRedDotNode(Scene ZoneScene, string target, bool isRemoveView = true)
        {
            RedDotComponent RedDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (RedDotComponent == null)
            {
                return;
            }

            RedDotComponent.RemoveRedDotNode(target);
            if (isRemoveView)
            {
                RedDotComponent.RemoveRedDotView(target, out RedDotMonoView redDotMonoView);
            }
        }
        
        
        /// <summary>
        /// 增加红点节点显示层
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="target"></param>
        /// <param name="monoView"></param>
        public static void AddRedDotNodeView(Scene ZoneScene, string target, GameObject gameObject,Vector3 RedDotScale,Vector2 PositionOffset )
        {
            RedDotComponent RedDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (RedDotComponent == null)
            {
                return;
            }
            RedDotMonoView monoView = gameObject.GetComponent<RedDotMonoView>()??gameObject.AddComponent<RedDotMonoView>();
            monoView.RedDotScale = RedDotScale;
            monoView.PositionOffset = PositionOffset;
            RedDotComponent.AddRedDotView(target, monoView);
        }
        
        
        /// <summary>
        /// 增加红点节点显示层
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="target"></param>
        /// <param name="monoView"></param>
        public static void AddRedDotNodeView(Scene ZoneScene, string target, RedDotMonoView monoView)
        {
            RedDotComponent RedDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (RedDotComponent == null)
            {
                return;
            }
            RedDotComponent.AddRedDotView(target, monoView);
        }

        /// <summary>
        /// 移除红点节点显示层
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="target"></param>
        /// <param name="monoView"></param>
        public static void RemoveRedDotView(Scene ZoneScene, string target, out RedDotMonoView monoView)
        {
            monoView = null;
            RedDotComponent RedDotComponent = ZoneScene?.GetComponent<RedDotComponent>();
            if (RedDotComponent == null)
            {
                return;
            }

            RedDotComponent.RemoveRedDotView(target, out monoView);
        }
        
        public static bool HideRedDotNode(Scene ZoneScene, string target)
        {
            RedDotComponent redDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (redDotComponent == null)
            {
                return false;
            }
            return redDotComponent.HideRedDotNode(target);
        }
        
        public static bool ShowRedDotNode(Scene ZoneScene, string target)
        {
            if (IsLogicAlreadyShow(ZoneScene, target))
            {
                return false;
            }
            RedDotComponent redDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (redDotComponent == null)
            {
                return false;
            }
            return redDotComponent.ShowRedDotNode(target);
        }
        
        public static bool IsLogicAlreadyShow(Scene ZoneScene, string target)
        {
            RedDotComponent redDotComponent = ZoneScene.GetComponent<RedDotComponent>();
            if (redDotComponent == null)
            {
                Log.Error("redDotComponent is not exist!");
                return false;
            }

            if (!redDotComponent.RedDotNodeRetainCount.ContainsKey(target))
            {
                return false;
            }
            
            return redDotComponent.RedDotNodeRetainCount[target] >= 1;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zoneScene"></param>
        /// <param name="target"></param>
        /// <param name="Count"></param>
        public static void RefreshRedDotViewCount(Scene zoneScene, string target, int Count)
        {
            RedDotComponent redDotComponent = zoneScene.GetComponent<RedDotComponent>();
            if (redDotComponent == null)
            {
                return;
            }
            redDotComponent.RefreshRedDotViewCount(target,Count);
        }
    }
}