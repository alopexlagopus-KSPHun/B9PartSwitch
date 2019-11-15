using System;
using B9PartSwitch.Fishbones.Context;

namespace B9PartSwitch.Fishbones.Parsers
{
    public class NodeObjectWrapperNodeObject : INodeObjectWrapper
    {
        public readonly Type type;

        public NodeObjectWrapperNodeObject(Type type)
        {
            type.ThrowIfNullArgument(nameof(type));
            this.type = type;
        }

        public void Load(ref object obj, ConfigNode node, OperationContext context)
        {
            node.ThrowIfNullArgument(nameof(node));
            context.ThrowIfNullArgument(nameof(context));

            if (obj.IsNull()) obj = Activator.CreateInstance(type);

            obj.LoadFields(node, context);
        }

        public ConfigNode Save(object obj, OperationContext context)
        {
            obj.ThrowIfNullArgument(nameof(obj));
            context.ThrowIfNullArgument(nameof(context));

            ConfigNode node = new ConfigNode();
            obj.SaveFields(node, context);
            return node;
        }
    }
}
