using AutoMapper;

namespace Application.Common.Mappings {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T> {
        /// <summary>
        /// Mapping
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        void Mapping (Profile profile) => profile.CreateMap (typeof (T), GetType ()).ReverseMap ();
    }
}