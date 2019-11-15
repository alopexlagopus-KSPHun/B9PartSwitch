using System;
using System.Collections.Generic;
using B9PartSwitch.Fishbones;
using B9PartSwitch.Fishbones.Context;

namespace B9PartSwitch
{
    public class MaterialModifierInfo : IContextualNode
    {
        public class TexturePropertyModifierInfo : IContextualNode
        {
            [NodeData]
            public string name;

            [NodeData(name = "currentTexture")]
            public string currentTextureName;

            [NodeData(name = "texture")]
            public string newTexturePath;

            [NodeData]
            public bool isNormalMap = false;

            public void Load(ConfigNode node, OperationContext context) => this.LoadFields(node, context);

            public void Save(ConfigNode node, OperationContext context) => this.SaveFields(node, context);
        }

        [NodeData]
        public string name;

        [NodeData(name = "baseTransform")]
        public List<string> baseTransformNames;

        [NodeData(name = "transform")]
        public List<string> transformNames;

        public void Load(ConfigNode node, OperationContext context) => this.LoadFields(node, context);

        public void Save(ConfigNode node, OperationContext context) => this.SaveFields(node, context);
    }
}
